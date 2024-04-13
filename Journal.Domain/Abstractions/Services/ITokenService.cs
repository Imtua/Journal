using Journal.Domain.Contracts;
using System.Security.Claims;

namespace Journal.Domain.Abstractions.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        
        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);

        Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto);
    }
}
