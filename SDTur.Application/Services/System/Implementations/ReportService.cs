using AutoMapper;
using SDTur.Application.DTOs.System.Report;
using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.System.Interfaces;

namespace SDTur.Application.Services.System.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            var reports = await _unitOfWork.Reports.GetAllAsync();
            return _mapper.Map<IEnumerable<ReportDto>>(reports);
        }

        public async Task<ReportDto?> GetByIdAsync(int id)
        {
            var report = await _unitOfWork.Reports.GetByIdAsync(id);
            return report != null ? _mapper.Map<ReportDto>(report) : null;
        }

        public async Task<IEnumerable<ReportDto>> GetByReportTypeAsync(string reportType)
        {
            var reports = await _unitOfWork.Reports.GetByReportTypeAsync(reportType);
            return _mapper.Map<IEnumerable<ReportDto>>(reports);
        }

        public async Task<IEnumerable<ReportDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var reports = await _unitOfWork.Reports.GetByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<ReportDto>>(reports);
        }

        public async Task<IEnumerable<ReportDto>> GetByGeneratedByAsync(string generatedBy)
        {
            var reports = await _unitOfWork.Reports.GetByGeneratedByAsync(generatedBy);
            return _mapper.Map<IEnumerable<ReportDto>>(reports);
        }

        public async Task<ReportDto?> CreateAsync(CreateReportDto createDto)
        {
            var entity = _mapper.Map<Report>(createDto);
            var created = await _unitOfWork.Reports.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ReportDto>(created);
        }

        public async Task<ReportDto?> UpdateAsync(UpdateReportDto updateDto)
        {
            var entity = await _unitOfWork.Reports.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.Reports.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ReportDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Reports.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<string> GenerateReportAsync(string reportType, string parameters)
        {
            // Burada rapor oluşturma mantığı implement edilecek
            // PDF, Excel vb. formatlarda rapor oluşturulacak
            var reportName = $"{reportType}_{DateTime.Now:yyyyMMdd_HHmmss}";
            var filePath = $"/reports/{reportName}.pdf";
            
            var report = new Report
            {
                ReportName = reportName,
                ReportType = reportType,
                ReportDate = DateTime.Now,
                Parameters = parameters,
                GeneratedBy = "System",
                FilePath = filePath,
                FileType = "PDF",
                IsActive = true
            };
            
            await _unitOfWork.Reports.AddAsync(report);
            await _unitOfWork.SaveChangesAsync();
            
            return filePath;
        }
    }
} 