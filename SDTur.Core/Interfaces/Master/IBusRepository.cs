using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Master
{
    public interface IBusRepository : IRepository<Bus>
    {
        Task<IEnumerable<Bus>> GetActiveBusesAsync();
        Task<IEnumerable<Bus>> GetAvailableBusesAsync();
    }
} 