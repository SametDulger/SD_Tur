using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class TourScheduleRepository : Repository<TourSchedule>, ITourScheduleRepository
    {
        public TourScheduleRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<TourSchedule> GetTourScheduleWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(ts => ts.Tour)
                .Include(ts => ts.Tickets)
                .Include(ts => ts.TourExpenses)
                .Include(ts => ts.TourIncomes)
                .FirstOrDefaultAsync(ts => ts.Id == id);
        }

        public async Task<IEnumerable<TourSchedule>> GetTourSchedulesByTourAsync(int tourId)
        {
            return await _dbSet
                .Include(ts => ts.Tour)
                .Where(ts => ts.TourId == tourId)
                .OrderBy(ts => ts.TourDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourSchedule>> GetTourSchedulesByDateAsync(DateTime date)
        {
            return await _dbSet
                .Include(ts => ts.Tour)
                .Where(ts => ts.TourDate.Date == date.Date)
                .OrderBy(ts => ts.TourDate)
                .ToListAsync();
        }
    }
} 