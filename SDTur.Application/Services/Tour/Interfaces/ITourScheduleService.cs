using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Tour.TourSchedule;

namespace SDTur.Application.Services.Tour.Interfaces
{
    public interface ITourScheduleService
    {
        Task<IEnumerable<TourScheduleDto>> GetAllTourSchedulesAsync();
        Task<TourScheduleDetailDto?> GetByIdAsync(int id);
        Task<TourScheduleDetailDto?> GetTourScheduleByIdAsync(int id);
        Task<IEnumerable<TourScheduleDto>> GetByTourAsync(int tourId);
        Task<IEnumerable<TourScheduleDto>> GetTourSchedulesByTourAsync(int tourId);
        Task<IEnumerable<TourScheduleDto>> GetByDateAsync(DateTime date);
        Task<IEnumerable<TourScheduleDto>> GetTourSchedulesByDateAsync(DateTime date);
        Task<TourScheduleDto?> CreateAsync(CreateTourScheduleDto createTourScheduleDto);
        Task<TourScheduleDto?> UpdateAsync(UpdateTourScheduleDto updateTourScheduleDto);
        Task DeleteTourScheduleAsync(int id);
        Task CompleteTourScheduleAsync(int id);
    }
} 