namespace Journal.Domain.Contracts.User
{
    public record RegisterUserDto(string Login, string Password, string PasswordConfirm);
}
