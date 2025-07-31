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
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Hotel>> GetActiveHotelsAsync()
        {
            return await _dbSet.Where(h => h.IsActive).OrderBy(h => h.Order).ToListAsync();
        }

        public async Task<Hotel> GetHotelWithRegionAsync(int id)
        {
            return await _dbSet
                .Include(h => h.Region)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByRegionAsync(int regionId)
        {
            return await _dbSet
                .Include(h => h.Region)
                .Where(h => h.RegionId == regionId && h.IsActive)
                .OrderBy(h => h.Order)
                .ToListAsync();
        }

        public async Task<IEnumerable<Hotel>> GetHotelsOrderedByRegionAndOrderAsync()
        {
            return await _dbSet
                .Include(h => h.Region)
                .Where(h => h.IsActive)
                .OrderByDescending(h => h.Region.DistanceFromKemer)
                .ThenBy(h => h.Order)
                .ToListAsync();
        }
    }
} 