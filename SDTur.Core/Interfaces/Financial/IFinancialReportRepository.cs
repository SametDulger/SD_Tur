using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Financial
{
    public interface IFinancialReportRepository : IRepository<FinancialReport>
    {
        Task<IEnumerable<FinancialReport>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<FinancialReport>> GetByReportTypeAsync(string reportType);
        Task<IEnumerable<FinancialReport>> GetByStatusAsync(string status);
        Task<FinancialReport> GetLatestByTypeAsync(string reportType);
        Task<IEnumerable<FinancialReport>> GetByEmployeeAsync(int employeeId);
    }
} 