using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
{
    public class TourReportService : ITourReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TourReportDto>> GetAllAsync()
        {
            var tourReports = await _unitOfWork.TourReports.GetAllAsync();
            return _mapper.Map<IEnumerable<TourReportDto>>(tourReports);
        }

        public async Task<TourReportDto> GetByIdAsync(int id)
        {
            var tourReport = await _unitOfWork.TourReports.GetByIdAsync(id);
            return _mapper.Map<TourReportDto>(tourReport);
        }

        public async Task<IEnumerable<TourReportDto>> GetByTourAsync(int tourId)
        {
            var tourReports = await _unitOfWork.TourReports.GetByTourAsync(tourId);
            return _mapper.Map<IEnumerable<TourReportDto>>(tourReports);
        }

        public async Task<IEnumerable<TourReportDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var tourReports = await _unitOfWork.TourReports.GetByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<TourReportDto>>(tourReports);
        }

        public async Task<IEnumerable<TourReportDto>> GetByReportTypeAsync(string reportType)
        {
            var tourReports = await _unitOfWork.TourReports.GetByReportTypeAsync(reportType);
            return _mapper.Map<IEnumerable<TourReportDto>>(tourReports);
        }

        public async Task<IEnumerable<TourReportDto>> GetByStatusAsync(string status)
        {
            var tourReports = await _unitOfWork.TourReports.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<TourReportDto>>(tourReports);
        }

        public async Task<IEnumerable<TourReportDto>> GetByEmployeeAsync(int employeeId)
        {
            var tourReports = await _unitOfWork.TourReports.GetByEmployeeAsync(employeeId);
            return _mapper.Map<IEnumerable<TourReportDto>>(tourReports);
        }

        public async Task<TourReportDto> GetLatestByTourAsync(int tourId)
        {
            var tourReport = await _unitOfWork.TourReports.GetLatestByTourAsync(tourId);
            return _mapper.Map<TourReportDto>(tourReport);
        }

        public async Task<TourReportDto> CreateAsync(CreateTourReportDto createDto)
        {
            var tourReport = _mapper.Map<TourReport>(createDto);
            tourReport.IsActive = true;
            
            await _unitOfWork.TourReports.AddAsync(tourReport);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourReportDto>(tourReport);
        }

        public async Task<TourReportDto> UpdateAsync(UpdateTourReportDto updateDto)
        {
            var existingTourReport = await _unitOfWork.TourReports.GetByIdAsync(updateDto.Id);
            if (existingTourReport == null)
                throw new ArgumentException("Tour report not found");
            
            _mapper.Map(updateDto, existingTourReport);
            
            await _unitOfWork.TourReports.UpdateAsync(existingTourReport);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourReportDto>(existingTourReport);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TourReports.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 