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
                .Where(ti => ti.TourScheduleId == tourScheduleId && ti.IsActive && !ti.IsDeleted)
                .OrderBy(ti => ti.IncomeDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourIncome>> GetIncomesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(ti => ti.IncomeDate >= startDate && ti.IncomeDate <= endDate && ti.IsActive && !ti.IsDeleted)
                .OrderBy(ti => ti.IncomeDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourIncome>> GetIncomesByCategoryAsync(string category)
        {
            return await _dbSet
                .Include(ti => ti.TourSchedule)
                .Where(ti => ti.Category == category && ti.IsActive && !ti.IsDeleted)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalIncomesByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Where(ti => ti.TourScheduleId == tourScheduleId && ti.IsActive && !ti.IsDeleted)
                .SumAsync(ti => ti.Amount);
        }
    }
} 