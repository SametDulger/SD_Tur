using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface IBusService
    {
        Task<IEnumerable<BusDto>> GetAllBusesAsync();
        Task<IEnumerable<BusDto>> GetActiveBusesAsync();
        Task<BusDto> GetBusByIdAsync(int id);
        Task<IEnumerable<BusDto>> GetAvailableBusesAsync();
        Task<BusDto> CreateBusAsync(CreateBusDto createBusDto);
        Task<BusDto> UpdateBusAsync(UpdateBusDto updateBusDto);
        Task DeleteBusAsync(int id);
    }
} 