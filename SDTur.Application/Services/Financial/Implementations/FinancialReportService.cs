using AutoMapper;
using SDTur.Application.DTOs.Financial.FinancialReport;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Financial.Interfaces;

namespace SDTur.Application.Services.Financial.Implementations
{
    public class FinancialReportService : IFinancialReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FinancialReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FinancialReportDto>> GetAllAsync()
        {
            var financialReports = await _unitOfWork.FinancialReports.GetAllAsync();
            return _mapper.Map<IEnumerable<FinancialReportDto>>(financialReports);
        }

        public async Task<FinancialReportDto> GetByIdAsync(int id)
        {
            var financialReport = await _unitOfWork.FinancialReports.GetByIdAsync(id);
            return _mapper.Map<FinancialReportDto>(financialReport);
        }

        public async Task<IEnumerable<FinancialReportDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var financialReports = await _unitOfWork.FinancialReports.GetByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<FinancialReportDto>>(financialReports);
        }

        public async Task<IEnumerable<FinancialReportDto>> GetByReportTypeAsync(string reportType)
        {
            var financialReports = await _unitOfWork.FinancialReports.GetByReportTypeAsync(reportType);
            return _mapper.Map<IEnumerable<FinancialReportDto>>(financialReports);
        }

        public async Task<IEnumerable<FinancialReportDto>> GetByStatusAsync(string status)
        {
            var financialReports = await _unitOfWork.FinancialReports.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<FinancialReportDto>>(financialReports);
        }

        public async Task<FinancialReportDto> GetLatestByTypeAsync(string reportType)
        {
            var financialReport = await _unitOfWork.FinancialReports.GetLatestByTypeAsync(reportType);
            return _mapper.Map<FinancialReportDto>(financialReport);
        }

        public async Task<IEnumerable<FinancialReportDto>> GetByEmployeeAsync(int employeeId)
        {
            var financialReports = await _unitOfWork.FinancialReports.GetByEmployeeAsync(employeeId);
            return _mapper.Map<IEnumerable<FinancialReportDto>>(financialReports);
        }

        public async Task<FinancialReportDto> CreateAsync(CreateFinancialReportDto createDto)
        {
            var financialReport = _mapper.Map<FinancialReport>(createDto);
            financialReport.IsActive = true;
            
            await _unitOfWork.FinancialReports.AddAsync(financialReport);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<FinancialReportDto>(financialReport);
        }

        public async Task<FinancialReportDto> UpdateAsync(UpdateFinancialReportDto updateDto)
        {
            var existingFinancialReport = await _unitOfWork.FinancialReports.GetByIdAsync(updateDto.Id);
            if (existingFinancialReport == null)
                throw new ArgumentException("Financial report not found");
            
            _mapper.Map(updateDto, existingFinancialReport);
            
            await _unitOfWork.FinancialReports.UpdateAsync(existingFinancialReport);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<FinancialReportDto>(existingFinancialReport);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.FinancialReports.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 