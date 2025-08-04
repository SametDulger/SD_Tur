using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Tour.TourExpense;

namespace SDTur.Application.Services.Tour.Interfaces
{
    public interface ITourExpenseService
    {
        Task<IEnumerable<TourExpenseDto>> GetAllAsync();
        Task<TourExpenseDto?> GetByIdAsync(int id);
        Task<TourExpenseDto?> CreateAsync(CreateTourExpenseDto createDto);
        Task<TourExpenseDto?> UpdateAsync(UpdateTourExpenseDto updateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<TourExpenseDto>> GetByTourScheduleAsync(int tourScheduleId);
    }
} 