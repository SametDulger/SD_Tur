using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.System
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task<IEnumerable<RefreshToken>> GetActiveTokensByUserIdAsync(int userId);
        Task RevokeTokenAsync(string token, string reason = "User logout");
        Task RevokeAllUserTokensAsync(int userId, string reason = "User logout");
        Task CleanupExpiredTokensAsync();
    }
} 