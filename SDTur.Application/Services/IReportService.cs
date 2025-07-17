using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface IReportService
    {
        Task<IEnumerable<ReportDto>> GetAllAsync();
        Task<ReportDto> GetByIdAsync(int id);
        Task<IEnumerable<ReportDto>> GetByReportTypeAsync(string reportType);
        Task<IEnumerable<ReportDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<ReportDto>> GetByGeneratedByAsync(string generatedBy);
        Task<ReportDto> CreateAsync(CreateReportDto createDto);
        Task<ReportDto> UpdateAsync(UpdateReportDto updateDto);
        Task DeleteAsync(int id);
        Task<string> GenerateReportAsync(string reportType, string parameters);
    }
} 