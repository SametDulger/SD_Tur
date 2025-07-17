using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface IReportRepository : IRepository<Report>
    {
        Task<IEnumerable<Report>> GetByReportTypeAsync(string reportType);
        Task<IEnumerable<Report>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Report>> GetByGeneratedByAsync(string generatedBy);
    }
} 