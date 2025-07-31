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
    public class TourIncomeRepository : Repository<TourIncome>, ITourIncomeRepository
    {
        public TourIncomeRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TourIncome>> GetIncomesByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Where(ti => ti.TourScheduleId == tourScheduleId)
                .OrderBy(ti => ti.IncomeDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourIncome>> GetIncomesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(ti => ti.IncomeDate >= startDate && ti.IncomeDate <= endDate)
                .OrderBy(ti => ti.IncomeDate)
                .ToListAsync();
        }
    }
} 