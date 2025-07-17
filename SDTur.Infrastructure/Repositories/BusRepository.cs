using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class BusRepository : Repository<Bus>, IBusRepository
    {
        public BusRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Bus>> GetActiveBusesAsync()
        {
            return await _dbSet.Where(b => b.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Bus>> GetAvailableBusesAsync()
        {
            return await _dbSet.Where(b => b.IsActive).ToListAsync();
        }
    }
} 