using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Tour.Tour;

namespace SDTur.Application.Services.Tour.Interfaces
{
    public interface ITourService
    {
        Task<TourDto?> CreateAsync(CreateTourDto createDto);
        Task<TourDto?> UpdateAsync(UpdateTourDto updateDto);
        Task<IEnumerable<TourDto>> GetAllToursAsync();
        Task<IEnumerable<TourDto>> GetActiveToursAsync();
        Task<TourDto?> GetTourByIdAsync(int id);
        Task DeleteTourAsync(int id);
    }
} 