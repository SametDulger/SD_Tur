using AutoMapper;
using SDTur.Application.DTOs.Tour.TourSchedule;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.Application.Services.Tour.Implementations
{
    public class TourScheduleService : ITourScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TourScheduleDto>> GetAllTourSchedulesAsync()
        {
            var tourSchedules = await _unitOfWork.TourSchedules.GetAllAsync();
            return _mapper.Map<IEnumerable<TourScheduleDto>>(tourSchedules);
        }

        public async Task<TourScheduleDetailDto?> GetByIdAsync(int id)
        {
            try
            {
                var tourSchedule = await _unitOfWork.TourSchedules.GetScheduleWithDetailsAsync(id);
                return tourSchedule != null ? _mapper.Map<TourScheduleDetailDto>(tourSchedule) : null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TourScheduleDetailDto?> GetTourScheduleByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<TourScheduleDto>> GetByTourAsync(int tourId)
        {
            try
            {
                var tourSchedules = await _unitOfWork.TourSchedules.GetSchedulesByTourAsync(tourId);
                return _mapper.Map<IEnumerable<TourScheduleDto>>(tourSchedules);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TourScheduleDto>> GetTourSchedulesByTourAsync(int tourId)
        {
            return await GetByTourAsync(tourId);
        }

        public async Task<IEnumerable<TourScheduleDto>> GetByDateAsync(DateTime date)
        {
            try
            {
                var tourSchedules = await _unitOfWork.TourSchedules.GetSchedulesByDateRangeAsync(date, date);
                return _mapper.Map<IEnumerable<TourScheduleDto>>(tourSchedules);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TourScheduleDto>> GetTourSchedulesByDateAsync(DateTime date)
        {
            return await GetByDateAsync(date);
        }

        public async Task<TourScheduleDto?> CreateAsync(CreateTourScheduleDto createTourScheduleDto)
        {
            var entity = _mapper.Map<TourSchedule>(createTourScheduleDto);
            var created = await _unitOfWork.TourSchedules.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourScheduleDto>(created);
        }

        public async Task<TourScheduleDto?> UpdateAsync(UpdateTourScheduleDto updateTourScheduleDto)
        {
            var entity = await _unitOfWork.TourSchedules.GetByIdAsync(updateTourScheduleDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateTourScheduleDto, entity);
            var updated = await _unitOfWork.TourSchedules.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TourScheduleDto>(updated);
        }

        public async Task DeleteTourScheduleAsync(int id)
        {
            await _unitOfWork.TourSchedules.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CompleteTourScheduleAsync(int id)
        {
            var tourSchedule = await _unitOfWork.TourSchedules.GetByIdAsync(id);
            if (tourSchedule != null)
            {
                tourSchedule.IsCompleted = true;
                await _unitOfWork.TourSchedules.UpdateAsync(tourSchedule);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
} 