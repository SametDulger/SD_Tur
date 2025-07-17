using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface ITourIncomeService
    {
        Task<IEnumerable<TourIncomeDto>> GetAllAsync();
        Task<TourIncomeDto> GetByIdAsync(int id);
        Task<TourIncomeDto> CreateAsync(CreateTourIncomeDto createDto);
        Task<TourIncomeDto> UpdateAsync(UpdateTourIncomeDto updateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<TourIncomeDto>> GetByTourScheduleAsync(int tourScheduleId);
    }
} 