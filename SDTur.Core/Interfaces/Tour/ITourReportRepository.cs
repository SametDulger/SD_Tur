using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface ITourReportRepository : IRepository<TourReport>
    {
        Task<IEnumerable<TourReport>> GetByTourAsync(int tourId);
        Task<IEnumerable<TourReport>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<TourReport>> GetByReportTypeAsync(string reportType);
        Task<IEnumerable<TourReport>> GetByStatusAsync(string status);
        Task<TourReport> GetLatestByTourAsync(int tourId);
        Task<IEnumerable<TourReport>> GetByEmployeeAsync(int employeeId);
    }
} 