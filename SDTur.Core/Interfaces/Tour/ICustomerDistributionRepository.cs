using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface ICustomerDistributionRepository : IRepository<CustomerDistribution>
    {
        Task<IEnumerable<CustomerDistribution>> GetByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<CustomerDistribution>> GetByBusAsync(int busId);
        Task<IEnumerable<CustomerDistribution>> GetByTicketAsync(int ticketId);
        Task<IEnumerable<CustomerDistribution>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<CustomerDistribution>> GetByStatusAsync(string status);
    }
} 