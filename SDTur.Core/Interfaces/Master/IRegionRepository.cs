using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Master
{
    public interface IRegionRepository : IRepository<Region>
    {
        Task<IEnumerable<Region>> GetActiveRegionsAsync();
        Task<Region> GetRegionWithHotelsAsync(int id);
    }
} 