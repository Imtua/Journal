﻿using Journal.Domain.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Journal.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _jwtKey;

        private readonly string _issuer;

        private readonly string _audience;

        private readonly IBaseRepository<User> _userRepository;

        public TokenService(IOptions<JwtSettings> options, IBaseRepository<User> userRepository)
        {
            _jwtKey = options.Value.JwtKey;
            _issuer = options.Value.Issuer;
            _audience = options.Value.Audience;
            _userRepository = userRepository;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var credentinals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken =
                new JwtSecurityToken(_issuer, _audience, claims, null, DateTime.UtcNow.AddMinutes(10), credentinals);
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

        public string GenerateRefreshToken()
        {
            var randomNumbers = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumbers);
            return Convert.ToBase64String(randomNumbers);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey)),
                ValidateLifetime = true,
                ValidAudience = _audience,
                ValidIssuer = _audience,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var claimsPrincipal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException(ErrorMessage.InvalidToken);

            return claimsPrincipal;
        }

        public async Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto)
        {
            var accesToken = dto.AccessToken;
            var refreshToken = dto.RefreshToken;

            var claimPrincipal = GetPrincipalFromExpiredToken(accesToken);
            var userName = claimPrincipal.Identity?.Name;

            var user = await _userRepository.GetAll()
                .Include(u => u.UserToken)
                .FirstOrDefaultAsync(u => u.Login ==  userName);

            if (user == null || user.UserToken.RefreshToken != refreshToken
                || user.UserToken.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return new BaseResult<TokenDto>
                {
                    ErrorMessage = ErrorMessage.InvalidClientRequest,
                };
            }

            var newAccessToken = GenerateAccessToken(claimPrincipal.Claims);
            var newRefreshToken = GenerateRefreshToken();

            user.UserToken.RefreshToken = newRefreshToken;
            await _userRepository.UpdateAsync(user);

            return new BaseResult<TokenDto>
            {
                Data = new TokenDto
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken,
                }
            };
        }
    }
}
