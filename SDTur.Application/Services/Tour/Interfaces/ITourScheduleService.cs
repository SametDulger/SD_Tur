using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Tour.TourSchedule;

namespace SDTur.Application.Services.Tour.Interfaces
{
    public interface ITourScheduleService
    {
        Task<IEnumerable<TourScheduleDto>> GetAllTourSchedulesAsync();
        Task<TourScheduleDto> GetTourScheduleByIdAsync(int id);
        Task<IEnumerable<TourScheduleDto>> GetTourSchedulesByTourAsync(int tourId);
        Task<IEnumerable<TourScheduleDto>> GetTourSchedulesByDateAsync(DateTime date);
        Task<TourScheduleDto> CreateTourScheduleAsync(CreateTourScheduleDto createTourScheduleDto);
        Task<TourScheduleDto> UpdateTourScheduleAsync(UpdateTourScheduleDto updateTourScheduleDto);
        Task DeleteTourScheduleAsync(int id);
        Task CompleteTourScheduleAsync(int id);
    }
} 