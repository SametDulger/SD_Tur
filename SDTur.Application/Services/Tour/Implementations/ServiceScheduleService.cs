using AutoMapper;
using SDTur.Application.DTOs.Tour.ServiceSchedule;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.Application.Services.Tour.Implementations
{
    public class ServiceScheduleService : IServiceScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServiceScheduleDto>> GetAllAsync()
        {
            var serviceSchedules = await _unitOfWork.ServiceSchedules.GetAllAsync();
            return _mapper.Map<IEnumerable<ServiceScheduleDto>>(serviceSchedules);
        }

        public async Task<ServiceScheduleDto> GetByIdAsync(int id)
        {
            var serviceSchedule = await _unitOfWork.ServiceSchedules.GetByIdAsync(id);
            return _mapper.Map<ServiceScheduleDto>(serviceSchedule);
        }

        public async Task<ServiceScheduleDto> CreateAsync(CreateServiceScheduleDto createDto)
        {
            var serviceSchedule = _mapper.Map<ServiceSchedule>(createDto);
            serviceSchedule.IsActive = true;
            
            await _unitOfWork.ServiceSchedules.AddAsync(serviceSchedule);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<ServiceScheduleDto>(serviceSchedule);
        }

        public async Task<ServiceScheduleDto> UpdateAsync(UpdateServiceScheduleDto updateDto)
        {
            var serviceSchedule = await _unitOfWork.ServiceSchedules.GetByIdAsync(updateDto.Id);
            if (serviceSchedule == null)
                return null;

            _mapper.Map(updateDto, serviceSchedule);
            await _unitOfWork.ServiceSchedules.UpdateAsync(serviceSchedule);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<ServiceScheduleDto>(serviceSchedule);
        }

        public async Task DeleteAsync(int id)
        {
            var serviceSchedule = await _unitOfWork.ServiceSchedules.GetByIdAsync(id);
            if (serviceSchedule == null)
                return;

            await _unitOfWork.ServiceSchedules.DeleteAsync(serviceSchedule.Id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ServiceScheduleDto>> GetByTourAsync(int tourId)
        {
            var serviceSchedules = await _unitOfWork.ServiceSchedules.GetServiceSchedulesByTourAsync(tourId);
            return _mapper.Map<IEnumerable<ServiceScheduleDto>>(serviceSchedules);
        }

        public async Task<IEnumerable<ServiceScheduleDto>> GetByRegionAsync(int regionId)
        {
            var serviceSchedules = await _unitOfWork.ServiceSchedules.GetServiceSchedulesByRegionAsync(regionId);
            return _mapper.Map<IEnumerable<ServiceScheduleDto>>(serviceSchedules);
        }

        public async Task<IEnumerable<ServiceScheduleDto>> GetByDateAsync(DateTime date)
        {
            var serviceSchedules = await _unitOfWork.ServiceSchedules.GetServiceSchedulesByDateAsync(date);
            return _mapper.Map<IEnumerable<ServiceScheduleDto>>(serviceSchedules);
        }
    }
} 