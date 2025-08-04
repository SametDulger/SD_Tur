using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Master.Hotel;

namespace SDTur.Application.Services.Master.Interfaces
{
    public interface IHotelService
    {
        Task<HotelDto?> CreateAsync(CreateHotelDto createDto);
        Task<HotelDto?> UpdateAsync(UpdateHotelDto updateDto);
        Task<IEnumerable<HotelDto>> GetAllHotelsAsync();
        Task<IEnumerable<HotelDto>> GetActiveHotelsAsync();
        Task<HotelDto?> GetHotelByIdAsync(int id);
        Task<IEnumerable<HotelDto>> GetHotelsByRegionAsync(int regionId);
        Task DeleteHotelAsync(int id);
    }
} 