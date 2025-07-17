using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
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
                .Where(ss => ss.TourId == tourId && ss.IsActive)
                .OrderBy(ss => ss.ServiceTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceSchedule>> GetServiceSchedulesByRegionAsync(int regionId)
        {
            return await _dbSet
                .Include(ss => ss.Tour)
                .Where(ss => ss.RegionId == regionId && ss.IsActive)
                .OrderBy(ss => ss.ServiceTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceSchedule>> GetServiceSchedulesByDateAsync(DateTime date)
        {
            return await _dbSet
                .Include(ss => ss.Tour)
                .Include(ss => ss.Region)
                .Where(ss => ss.ServiceDate.Date == date.Date && ss.IsActive)
                .OrderBy(ss => ss.ServiceTime)
                .ToListAsync();
        }
    }
} 