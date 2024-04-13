namespace Journal.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Request to register a new user.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("register")]
        public async Task<ActionResult<BaseResult<UserDto>>> Register([FromBody]RegisterUserDto request)
        {
            var response = await _authService.Register(request);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Request to login for created users.
        /// </summary>
        /// <param name="request"></param>
        [HttpPost("login")]
        public async Task<ActionResult<BaseResult<TokenDto>>> Login([FromBody]LoginUserDto request)
        {
            var response = await _authService.Login(request);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
