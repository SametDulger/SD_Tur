using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface IRegionRepository : IRepository<Region>
    {
        Task<IEnumerable<Region>> GetActiveRegionsAsync();
        Task<Region> GetRegionWithHotelsAsync(int id);
    }
} 