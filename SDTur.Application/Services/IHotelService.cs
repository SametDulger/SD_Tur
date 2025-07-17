using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelDto>> GetAllHotelsAsync();
        Task<IEnumerable<HotelDto>> GetActiveHotelsAsync();
        Task<HotelDto> GetHotelByIdAsync(int id);
        Task<IEnumerable<HotelDto>> GetHotelsByRegionAsync(int regionId);
        Task<HotelDto> CreateHotelAsync(CreateHotelDto createHotelDto);
        Task<HotelDto> UpdateHotelAsync(UpdateHotelDto updateHotelDto);
        Task DeleteHotelAsync(int id);
    }
} 