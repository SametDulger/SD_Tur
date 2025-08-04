using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Tour;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.Tour
{
    public class TourRepository : Repository<SDTur.Core.Entities.Tour.Tour>, ITourRepository
    {
        public TourRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SDTur.Core.Entities.Tour.Tour>> GetActiveToursAsync()
        {
            return await _dbSet
                .Where(t => t.IsActive && !t.IsDeleted)
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<SDTur.Core.Entities.Tour.Tour?> GetTourWithSchedulesAsync(int id)
        {
            return await _dbSet
                .Include(t => t.TourSchedules)
                .FirstOrDefaultAsync(t => t.Id == id && t.IsActive && !t.IsDeleted);
        }
    }
} 