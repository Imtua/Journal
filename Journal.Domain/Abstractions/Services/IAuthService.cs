using Journal.Domain.Contracts;
using Journal.Domain.Contracts.User;

namespace Journal.Domain.Abstractions.Services
{
    /// <summary>
    /// Сервис, предназначенный для регистрации.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Регистрация пользователяю.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BaseResult<UserDto>> Register(RegisterUserDto dto);

        /// <summary>
        /// Авторизация пользователя.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BaseResult<TokenDto>> Login(LoginUserDto dto);
    }
}
