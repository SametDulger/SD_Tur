using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
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