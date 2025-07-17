using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface ITourService
    {
        Task<IEnumerable<TourDto>> GetAllToursAsync();
        Task<IEnumerable<TourDto>> GetActiveToursAsync();
        Task<TourDto> GetTourByIdAsync(int id);
        Task<TourDto> CreateTourAsync(CreateTourDto createTourDto);
        Task<TourDto> UpdateTourAsync(UpdateTourDto updateTourDto);
        Task DeleteTourAsync(int id);
    }
} 