using SDTur.Application.DTOs.System.Auth;

namespace SDTur.Application.Services.System.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateAccessTokenAsync(int userId, string username, string role);
        Task<string> GenerateRefreshTokenAsync();
        Task<RefreshTokenResponseDto> RefreshTokenAsync(string refreshToken);
        Task RevokeRefreshTokenAsync(string refreshToken, string reason = "User logout");
        Task<bool> ValidateRefreshTokenAsync(string refreshToken);
        Task<IEnumerable<string>> GetUserActiveTokensAsync(int userId);
    }
} 