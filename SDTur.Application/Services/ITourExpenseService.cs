using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface ITourExpenseService
    {
        Task<IEnumerable<TourExpenseDto>> GetAllAsync();
        Task<TourExpenseDto> GetByIdAsync(int id);
        Task<TourExpenseDto> CreateAsync(CreateTourExpenseDto createDto);
        Task<TourExpenseDto> UpdateAsync(UpdateTourExpenseDto updateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<TourExpenseDto>> GetByTourScheduleAsync(int tourScheduleId);
    }
} 