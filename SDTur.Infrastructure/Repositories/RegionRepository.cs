using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Region>> GetActiveRegionsAsync()
        {
            return await _dbSet.Where(r => r.IsActive).OrderBy(r => r.Order).ToListAsync();
        }

        public async Task<Region> GetRegionWithHotelsAsync(int id)
        {
            return await _dbSet
                .Include(r => r.Hotels)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
} 