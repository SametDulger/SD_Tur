using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Master.Bus;

namespace SDTur.Application.Services.Master.Interfaces
{
    public interface IBusService
    {
        Task<BusDto?> CreateAsync(CreateBusDto createDto);
        Task<BusDto?> UpdateAsync(UpdateBusDto updateDto);
        Task<IEnumerable<BusDto>> GetAllBusesAsync();
        Task<IEnumerable<BusDto>> GetActiveBusesAsync();
        Task<BusDto?> GetBusByIdAsync(int id);
        Task<IEnumerable<BusDto>> GetAvailableBusesAsync();
        Task DeleteBusAsync(int id);
    }
} 