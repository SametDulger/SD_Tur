using AutoMapper;
using SDTur.Application.DTOs.Tour.TourReport;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.Application.Services.Tour.Implementations
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

        public async Task<TourReportDto?> GetByIdAsync(int id)
        {
            var tourReport = await _unitOfWork.TourReports.GetByIdAsync(id);
            return tourReport != null ? _mapper.Map<TourReportDto>(tourReport) : null;
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

        public async Task<TourReportDto?> GetLatestByTourAsync(int tourId)
        {
            var tourReport = await _unitOfWork.TourReports.GetLatestByTourAsync(tourId);
            return tourReport != null ? _mapper.Map<TourReportDto>(tourReport) : null;
        }

        public async Task<TourReportDto?> CreateAsync(CreateTourReportDto createDto)
        {
            var entity = _mapper.Map<TourReport>(createDto);
            var created = await _unitOfWork.TourReports.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourReportDto>(created);
        }

        public async Task<TourReportDto?> UpdateAsync(UpdateTourReportDto updateDto)
        {
            var entity = await _unitOfWork.TourReports.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.TourReports.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourReportDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TourReports.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 