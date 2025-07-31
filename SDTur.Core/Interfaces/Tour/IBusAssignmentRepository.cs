using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface IBusAssignmentRepository : IRepository<BusAssignment>
    {
        Task<IEnumerable<BusAssignment>> GetByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<BusAssignment>> GetByBusAsync(int busId);
        Task<IEnumerable<BusAssignment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<BusAssignment>> GetByStatusAsync(string status);
    }
} 