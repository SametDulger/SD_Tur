namespace SDTur.Application.Services.System.Interfaces
{
    public interface IDistributedLockService
    {
        Task<bool> AcquireLockAsync(string key, TimeSpan expiry);
        Task<bool> ReleaseLockAsync(string key);
        Task<bool> ExtendLockAsync(string key, TimeSpan expiry);
        Task<bool> IsLockedAsync(string key);
    }
} 