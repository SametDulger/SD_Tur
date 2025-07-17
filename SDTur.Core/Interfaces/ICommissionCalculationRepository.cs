using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface ICommissionCalculationRepository : IRepository<CommissionCalculation>
    {
        Task<IEnumerable<CommissionCalculation>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<CommissionCalculation>> GetByTicketAsync(int ticketId);
        Task<IEnumerable<CommissionCalculation>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<CommissionCalculation>> GetByStatusAsync(string status);
        Task<decimal> GetTotalCommissionByEmployeeAsync(int employeeId, DateTime startDate, DateTime endDate);
    }
} 