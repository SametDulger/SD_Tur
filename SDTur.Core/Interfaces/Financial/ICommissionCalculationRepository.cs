using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Financial
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