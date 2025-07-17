using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
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