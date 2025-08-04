using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Financial.FinancialReport;

namespace SDTur.Application.Services.Financial.Interfaces
{
    public interface IFinancialReportService
    {
        Task<IEnumerable<FinancialReportDto>> GetAllAsync();
        Task<FinancialReportDto?> GetByIdAsync(int id);
        Task<IEnumerable<FinancialReportDto>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<FinancialReportDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<FinancialReportDto>> GetByReportTypeAsync(string reportType);
        Task<IEnumerable<FinancialReportDto>> GetByStatusAsync(string status);
        Task<FinancialReportDto?> GetLatestByTypeAsync(string reportType);
        Task<FinancialReportDto?> CreateAsync(CreateFinancialReportDto createDto);
        Task<FinancialReportDto?> UpdateAsync(UpdateFinancialReportDto updateDto);
        Task DeleteAsync(int id);
    }
} 