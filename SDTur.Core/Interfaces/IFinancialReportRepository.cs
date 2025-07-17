using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
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