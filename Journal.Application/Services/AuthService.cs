using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Journal.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseRepository<User> _userRepository;

        private readonly IBaseRepository<UserToken> _userTokenRepository;

        private readonly ITokenService _tokenService;   

        private readonly ILogger _logger;

        private readonly IMapper _mapper;

        public AuthService(IBaseRepository<User> userRepository,
            ILogger logger,
            IMapper mapper,
            IBaseRepository<UserToken> userTokenRepository,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
            _userTokenRepository = userTokenRepository;
            _tokenService = tokenService;
        }

        public async Task<BaseResult<UserDto>> Register(RegisterUserDto dto)
        {
            if (dto.Password != dto.PasswordConfirm)
            {
                return new BaseResult<UserDto>
                {
                    ErrorMessage = ErrorMessage.PasswordNotEqualPasswordConfirm,
                    ErrorCode = (int)ErrorCodes.PasswordNotEqualPasswordConfirm,
                };
            }
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Login == dto.Login);

                if (user != null)
                {
                    return new BaseResult<UserDto>
                    {
                        ErrorMessage = ErrorMessage.UserAlreadyExists,
                        ErrorCode = (int)ErrorCodes.UserAlreadyExists,
                    };
                }

                var hashUserPassword = HashPassword(dto.Password);

                user = new User
                {
                    Id = Guid.NewGuid(),
                    Login = dto.Login,
                    Password = hashUserPassword,
                };

                await _userRepository.CreateAsync(user);

                return new BaseResult<UserDto>
                {
                    Data = _mapper.Map<UserDto>(user)
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<UserDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }
        }

        public async Task<BaseResult<TokenDto>> Login(LoginUserDto dto)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Login == dto.Login);
                if (user == null)
                {
                    return new BaseResult<TokenDto>
                    {
                        ErrorMessage = ErrorMessage.UserNotFound,
                        ErrorCode = (int)ErrorCodes.UserNotFound,
                    };
                }
                if (!IsVerifyPassword(user.Password, dto.Password))
                {
                    return new BaseResult<TokenDto>
                    {
                        ErrorMessage = ErrorMessage.PasswordIsWrong,
                        ErrorCode = (int)ErrorCodes.PasswordIsWrong,
                    };
                }

                var userToken = await _userTokenRepository.GetAll().FirstOrDefaultAsync(t => t.UserId == user.Id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, "User")
                };

                var accessToken = _tokenService.GenerateAccessToken(claims);
                var refreshToken = _tokenService.GenerateRefreshToken();
                
                if (userToken == null)
                {
                    userToken = new UserToken
                    {
                        Id = Guid.NewGuid(),
                        UserId = user.Id,
                        RefreshToken = refreshToken,
                        RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7),
                    };
                    await _userTokenRepository.CreateAsync(userToken);
                }
                else
                {
                    userToken.RefreshToken = refreshToken;
                    userToken.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                    await _userTokenRepository.UpdateAsync(userToken);    
                }

                return new BaseResult<TokenDto>
                {
                    Data = new TokenDto
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshToken,
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<TokenDto>
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError,
                };
            }
        }

        private string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }   
        
        private bool IsVerifyPassword(string userPasswordHash, string userPassword)
        {
            var hash = HashPassword(userPassword);
            return userPasswordHash == hash;
        }
    }
}
