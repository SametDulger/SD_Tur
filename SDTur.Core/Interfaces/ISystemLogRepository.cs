using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface ISystemLogRepository : IRepository<SystemLog>
    {
        Task<IEnumerable<SystemLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<SystemLog>> GetByLogLevelAsync(string logLevel);
        Task<IEnumerable<SystemLog>> GetByCategoryAsync(string category);
        Task<IEnumerable<SystemLog>> GetByUserAsync(int userId);
        Task<IEnumerable<SystemLog>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<SystemLog>> GetByActionAsync(string action);
    }
} 