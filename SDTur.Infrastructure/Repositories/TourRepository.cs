using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class TourRepository : Repository<Tour>, ITourRepository
    {
        public TourRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tour>> GetActiveToursAsync()
        {
            return await _dbSet.Where(t => t.IsActive).ToListAsync();
        }

        public async Task<Tour> GetTourWithSchedulesAsync(int id)
        {
            return await _dbSet
                .Include(t => t.TourSchedules)
                .Include(t => t.ServiceSchedules)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
} 