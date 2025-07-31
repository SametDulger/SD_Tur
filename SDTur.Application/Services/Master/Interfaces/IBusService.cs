using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Master.Bus;

namespace SDTur.Application.Services.Master.Interfaces
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