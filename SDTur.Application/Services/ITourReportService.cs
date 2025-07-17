using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface ITourReportService
    {
        Task<IEnumerable<TourReportDto>> GetAllAsync();
        Task<TourReportDto> GetByIdAsync(int id);
        Task<IEnumerable<TourReportDto>> GetByTourAsync(int tourId);
        Task<IEnumerable<TourReportDto>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<TourReportDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<TourReportDto>> GetByReportTypeAsync(string reportType);
        Task<IEnumerable<TourReportDto>> GetByStatusAsync(string status);
        Task<TourReportDto> GetLatestByTourAsync(int tourId);
        Task<TourReportDto> CreateAsync(CreateTourReportDto createDto);
        Task<TourReportDto> UpdateAsync(UpdateTourReportDto updateDto);
        Task DeleteAsync(int id);
    }
} 