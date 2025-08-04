using SDTur.Application.DTOs.Tour.TourType;

namespace SDTur.Application.Services.Tour.Interfaces
{
    public interface ITourTypeService
    {
        Task<IEnumerable<TourTypeDto>> GetAllAsync();
        Task<IEnumerable<TourTypeDto>> GetActiveAsync();
        Task<TourTypeDto?> GetByIdAsync(int id);
    }
} 