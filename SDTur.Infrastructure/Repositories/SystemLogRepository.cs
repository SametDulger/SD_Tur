using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class SystemLogRepository : Repository<SystemLog>, ISystemLogRepository
    {
        public SystemLogRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SystemLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(sl => sl.User)
                .Include(sl => sl.Employee)
                .Where(sl => sl.LogDate >= startDate && sl.LogDate <= endDate && !sl.IsDeleted)
                .OrderByDescending(sl => sl.LogDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<SystemLog>> GetByLogLevelAsync(string logLevel)
        {
            return await _dbSet
                .Include(sl => sl.User)
                .Include(sl => sl.Employee)
                .Where(sl => sl.LogLevel == logLevel && !sl.IsDeleted)
                .OrderByDescending(sl => sl.LogDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<SystemLog>> GetByCategoryAsync(string category)
        {
            return await _dbSet
                .Include(sl => sl.User)
                .Include(sl => sl.Employee)
                .Where(sl => sl.Category == category && !sl.IsDeleted)
                .OrderByDescending(sl => sl.LogDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<SystemLog>> GetByUserAsync(int userId)
        {
            return await _dbSet
                .Include(sl => sl.User)
                .Include(sl => sl.Employee)
                .Where(sl => sl.UserId == userId && !sl.IsDeleted)
                .OrderByDescending(sl => sl.LogDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<SystemLog>> GetByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Include(sl => sl.User)
                .Include(sl => sl.Employee)
                .Where(sl => sl.EmployeeId == employeeId && !sl.IsDeleted)
                .OrderByDescending(sl => sl.LogDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<SystemLog>> GetByActionAsync(string action)
        {
            return await _dbSet
                .Include(sl => sl.User)
                .Include(sl => sl.Employee)
                .Where(sl => sl.Action == action && !sl.IsDeleted)
                .OrderByDescending(sl => sl.LogDate)
                .ToListAsync();
        }
    }
} 