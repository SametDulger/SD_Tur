using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Tour.TourIncome;

namespace SDTur.Application.Services.Tour.Interfaces
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