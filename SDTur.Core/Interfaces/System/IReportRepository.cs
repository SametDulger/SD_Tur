using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.System
{
    public interface IReportRepository : IRepository<Report>
    {
        Task<IEnumerable<Report>> GetByReportTypeAsync(string reportType);
        Task<IEnumerable<Report>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Report>> GetByGeneratedByAsync(string generatedBy);
    }
} 