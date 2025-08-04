using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Master;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.Master
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Region>> GetActiveRegionsAsync()
        {
            return await _dbSet
                .Where(r => r.IsActive && !r.IsDeleted)
                .OrderBy(r => r.Order)
                .ToListAsync();
        }

        public async Task<Region?> GetRegionWithHotelsAsync(int id)
        {
            return await _dbSet
                .Include(r => r.Hotels)
                .FirstOrDefaultAsync(r => r.Id == id && r.IsActive && !r.IsDeleted);
        }
    }
} 