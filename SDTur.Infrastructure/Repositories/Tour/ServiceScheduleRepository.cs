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
    public class ServiceScheduleRepository : Repository<ServiceSchedule>, IServiceScheduleRepository
    {
        public ServiceScheduleRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ServiceSchedule>> GetServiceSchedulesByTourAsync(int tourId)
        {
            return await _dbSet
                .Include(ss => ss.Region)
                .Where(ss => ss.TourId == tourId && ss.IsActive && !ss.IsDeleted)
                .OrderBy(ss => ss.ServiceTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceSchedule>> GetServiceSchedulesByRegionAsync(int regionId)
        {
            return await _dbSet
                .Include(ss => ss.Tour)
                .Where(ss => ss.RegionId == regionId && ss.IsActive && !ss.IsDeleted)
                .OrderBy(ss => ss.ServiceTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceSchedule>> GetServiceSchedulesByDateAsync(DateTime date)
        {
            return await _dbSet
                .Include(ss => ss.Tour)
                .Include(ss => ss.Region)
                .Where(ss => ss.ServiceDate.Date == date.Date && ss.IsActive && !ss.IsDeleted)
                .OrderBy(ss => ss.ServiceTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceSchedule>> GetSchedulesByRegionAsync(int regionId)
        {
            return await _dbSet
                .Include(ss => ss.Tour)
                .Include(ss => ss.Region)
                .Where(ss => ss.RegionId == regionId && ss.IsActive && !ss.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceSchedule>> GetSchedulesByDateAsync(DateTime date)
        {
            return await _dbSet
                .Include(ss => ss.Tour)
                .Include(ss => ss.Region)
                .Where(ss => ss.ServiceDate.Date == date.Date && ss.IsActive && !ss.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceSchedule>> GetActiveSchedulesAsync()
        {
            return await _dbSet
                .Include(ss => ss.Tour)
                .Include(ss => ss.Region)
                .Where(ss => ss.IsActive && !ss.IsDeleted)
                .ToListAsync();
        }
    }
} 