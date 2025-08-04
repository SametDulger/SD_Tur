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

        public async Task<ServiceScheduleDto?> GetByIdAsync(int id)
        {
            var serviceSchedule = await _unitOfWork.ServiceSchedules.GetByIdAsync(id);
            return serviceSchedule != null ? _mapper.Map<ServiceScheduleDto>(serviceSchedule) : null;
        }

        public async Task<ServiceScheduleDto?> CreateAsync(CreateServiceScheduleDto createDto)
        {
            var entity = _mapper.Map<ServiceSchedule>(createDto);
            var created = await _unitOfWork.ServiceSchedules.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ServiceScheduleDto>(created);
        }

        public async Task<ServiceScheduleDto?> UpdateAsync(UpdateServiceScheduleDto updateDto)
        {
            var entity = await _unitOfWork.ServiceSchedules.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.ServiceSchedules.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ServiceScheduleDto>(updated);
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
            try
            {
                var serviceSchedules = await _unitOfWork.ServiceSchedules.GetAllAsync();
                var filteredSchedules = serviceSchedules.Where(ss => ss.TourId == tourId);
                return _mapper.Map<IEnumerable<ServiceScheduleDto>>(filteredSchedules);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ServiceScheduleDto>> GetByRegionAsync(int regionId)
        {
            try
            {
                var serviceSchedules = await _unitOfWork.ServiceSchedules.GetSchedulesByRegionAsync(regionId);
                return _mapper.Map<IEnumerable<ServiceScheduleDto>>(serviceSchedules);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ServiceScheduleDto>> GetByDateAsync(DateTime date)
        {
            try
            {
                var serviceSchedules = await _unitOfWork.ServiceSchedules.GetSchedulesByDateAsync(date);
                return _mapper.Map<IEnumerable<ServiceScheduleDto>>(serviceSchedules);
            }
            catch
            {
                throw;
            }
        }
    }
} 