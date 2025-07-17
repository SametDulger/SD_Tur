using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface IBusRepository : IRepository<Bus>
    {
        Task<IEnumerable<Bus>> GetActiveBusesAsync();
        Task<IEnumerable<Bus>> GetAvailableBusesAsync();
    }
} 