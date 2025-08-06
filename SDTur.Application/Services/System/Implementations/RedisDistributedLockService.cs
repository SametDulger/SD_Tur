using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using SDTur.Application.Services.System.Interfaces;

namespace SDTur.Application.Services.System.Implementations
{
    public class RedisDistributedLockService : IDistributedLockService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<RedisDistributedLockService> _logger;

        public RedisDistributedLockService(IDistributedCache cache, ILogger<RedisDistributedLockService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<bool> AcquireLockAsync(string key, TimeSpan expiry)
        {
            try
            {
                var lockKey = $"lock:{key}";
                var lockValue = Guid.NewGuid().ToString();
                
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = expiry
                };

                await _cache.SetStringAsync(lockKey, lockValue, options);
                
                // Verify we got the lock
                var acquiredValue = await _cache.GetStringAsync(lockKey);
                if (acquiredValue == lockValue)
                {
                    _logger.LogDebug("Lock acquired for key: {Key}", key);
                    return true;
                }

                _logger.LogWarning("Failed to acquire lock for key: {Key}", key);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error acquiring lock for key: {Key}", key);
                return false;
            }
        }

        public async Task<bool> ReleaseLockAsync(string key)
        {
            try
            {
                var lockKey = $"lock:{key}";
                await _cache.RemoveAsync(lockKey);
                
                _logger.LogDebug("Lock released for key: {Key}", key);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error releasing lock for key: {Key}", key);
                return false;
            }
        }

        public async Task<bool> ExtendLockAsync(string key, TimeSpan expiry)
        {
            try
            {
                var lockKey = $"lock:{key}";
                var currentValue = await _cache.GetStringAsync(lockKey);
                
                if (string.IsNullOrEmpty(currentValue))
                {
                    return false;
                }

                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = expiry
                };

                await _cache.SetStringAsync(lockKey, currentValue, options);
                
                _logger.LogDebug("Lock extended for key: {Key}", key);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error extending lock for key: {Key}", key);
                return false;
            }
        }

        public async Task<bool> IsLockedAsync(string key)
        {
            try
            {
                var lockKey = $"lock:{key}";
                var value = await _cache.GetStringAsync(lockKey);
                return !string.IsNullOrEmpty(value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking lock status for key: {Key}", key);
                return false;
            }
        }
    }
} 