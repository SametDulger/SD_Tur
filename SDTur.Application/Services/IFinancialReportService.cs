using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface IFinancialReportService
    {
        Task<IEnumerable<FinancialReportDto>> GetAllAsync();
        Task<FinancialReportDto> GetByIdAsync(int id);
        Task<IEnumerable<FinancialReportDto>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<FinancialReportDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<FinancialReportDto>> GetByReportTypeAsync(string reportType);
        Task<IEnumerable<FinancialReportDto>> GetByStatusAsync(string status);
        Task<FinancialReportDto> GetLatestByTypeAsync(string reportType);
        Task<FinancialReportDto> CreateAsync(CreateFinancialReportDto createDto);
        Task<FinancialReportDto> UpdateAsync(UpdateFinancialReportDto updateDto);
        Task DeleteAsync(int id);
    }
} 