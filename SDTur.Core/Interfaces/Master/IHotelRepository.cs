using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Master
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<IEnumerable<Hotel>> GetActiveHotelsAsync();
        Task<Hotel> GetHotelWithRegionAsync(int id);
        Task<IEnumerable<Hotel>> GetHotelsByRegionAsync(int regionId);
    }
} 