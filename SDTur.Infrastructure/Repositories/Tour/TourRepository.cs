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
                .Include(t => t.TourType)
                .Where(t => t.IsActive && !t.IsDeleted)
                .OrderBy(t => t.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<SDTur.Core.Entities.Tour.Tour?> GetTourWithSchedulesAsync(int id)
        {
            return await _dbSet
                .Include(t => t.TourType)
                .Include(t => t.TourSchedules.Where(ts => ts.IsActive && !ts.IsDeleted))
                .Include(t => t.ServiceSchedules.Where(ss => ss.IsActive && !ss.IsDeleted))
                .Include(t => t.Tickets.Where(ticket => ticket.IsActive && !ticket.IsDeleted))
                .FirstOrDefaultAsync(t => t.Id == id && t.IsActive && !t.IsDeleted);
        }

        public async Task<SDTur.Core.Entities.Tour.Tour?> GetTourWithFullDetailsAsync(int id)
        {
            return await _dbSet
                .Include(t => t.TourType)
                .Include(t => t.TourSchedules.Where(ts => ts.IsActive && !ts.IsDeleted))
                .Include(t => t.ServiceSchedules.Where(ss => ss.IsActive && !ss.IsDeleted))
                .Include(t => t.Tickets.Where(ticket => ticket.IsActive && !ticket.IsDeleted))
                .FirstOrDefaultAsync(t => t.Id == id && t.IsActive && !t.IsDeleted);
        }

        public async Task<IEnumerable<SDTur.Core.Entities.Tour.Tour>> GetToursWithFullDetailsAsync()
        {
            return await _dbSet
                .Include(t => t.TourType)
                .Include(t => t.TourSchedules.Where(ts => ts.IsActive && !ts.IsDeleted))
                .Include(t => t.ServiceSchedules.Where(ss => ss.IsActive && !ss.IsDeleted))
                .Include(t => t.Tickets.Where(ticket => ticket.IsActive && !ticket.IsDeleted))
                .Where(t => t.IsActive && !t.IsDeleted)
                .OrderBy(t => t.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<SDTur.Core.Entities.Tour.Tour>> GetToursByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(t => t.TourType)
                .Include(t => t.TourSchedules.Where(ts => ts.IsActive && !ts.IsDeleted && 
                                                          ts.TourDate >= startDate && ts.TourDate <= endDate))
                .Where(t => t.IsActive && !t.IsDeleted && 
                           t.TourSchedules.Any(ts => ts.IsActive && !ts.IsDeleted && 
                                                    ts.TourDate >= startDate && ts.TourDate <= endDate))
                .OrderBy(t => t.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<SDTur.Core.Entities.Tour.Tour>> GetToursByDestinationAsync(string destination)
        {
            return await _dbSet
                .Include(t => t.TourType)
                .Where(t => t.IsActive && !t.IsDeleted && 
                           t.Destination.Contains(destination))
                .OrderBy(t => t.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<SDTur.Core.Entities.Tour.Tour>> GetToursByTypeAsync(int tourTypeId)
        {
            return await _dbSet
                .Include(t => t.TourType)
                .Where(t => t.IsActive && !t.IsDeleted && 
                           t.TourTypeId == tourTypeId)
                .OrderBy(t => t.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<SDTur.Core.Entities.Tour.Tour>> GetToursByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _dbSet
                .Include(t => t.TourType)
                .Where(t => t.IsActive && !t.IsDeleted && 
                           t.Price >= minPrice && t.Price <= maxPrice)
                .OrderBy(t => t.Price)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetActiveToursCountAsync()
        {
            return await _dbSet
                .Where(t => t.IsActive && !t.IsDeleted)
                .CountAsync();
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _dbSet
                .Where(t => t.IsActive && !t.IsDeleted)
                .SumAsync(t => t.TotalRevenue);
        }
    }
} 