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
    public class BusRepository : Repository<Bus>, IBusRepository
    {
        public BusRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Bus>> GetActiveBusesAsync()
        {
            return await _dbSet.Where(b => b.IsActive && !b.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Bus>> GetAvailableBusesAsync()
        {
            return await _dbSet.Where(b => b.IsActive && !b.IsDeleted).ToListAsync();
        }
    }
} 