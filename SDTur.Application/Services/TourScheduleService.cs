using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
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

        public async Task<TourScheduleDto> GetTourScheduleByIdAsync(int id)
        {
            var tourSchedule = await _unitOfWork.TourSchedules.GetTourScheduleWithDetailsAsync(id);
            return _mapper.Map<TourScheduleDto>(tourSchedule);
        }

        public async Task<IEnumerable<TourScheduleDto>> GetTourSchedulesByTourAsync(int tourId)
        {
            var tourSchedules = await _unitOfWork.TourSchedules.GetTourSchedulesByTourAsync(tourId);
            return _mapper.Map<IEnumerable<TourScheduleDto>>(tourSchedules);
        }

        public async Task<IEnumerable<TourScheduleDto>> GetTourSchedulesByDateAsync(DateTime date)
        {
            var tourSchedules = await _unitOfWork.TourSchedules.GetTourSchedulesByDateAsync(date);
            return _mapper.Map<IEnumerable<TourScheduleDto>>(tourSchedules);
        }

        public async Task<TourScheduleDto> CreateTourScheduleAsync(CreateTourScheduleDto createTourScheduleDto)
        {
            var tourSchedule = _mapper.Map<TourSchedule>(createTourScheduleDto);
            
            var createdTourSchedule = await _unitOfWork.TourSchedules.AddAsync(tourSchedule);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourScheduleDto>(createdTourSchedule);
        }

        public async Task<TourScheduleDto> UpdateTourScheduleAsync(UpdateTourScheduleDto updateTourScheduleDto)
        {
            var existingTourSchedule = await _unitOfWork.TourSchedules.GetByIdAsync(updateTourScheduleDto.Id);
            if (existingTourSchedule == null)
                return null;

            _mapper.Map(updateTourScheduleDto, existingTourSchedule);
            
            var updatedTourSchedule = await _unitOfWork.TourSchedules.UpdateAsync(existingTourSchedule);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<TourScheduleDto>(updatedTourSchedule);
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