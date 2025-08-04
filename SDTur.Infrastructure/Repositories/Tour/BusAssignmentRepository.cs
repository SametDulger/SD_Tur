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
    public class BusAssignmentRepository : Repository<BusAssignment>, IBusAssignmentRepository
    {
        public BusAssignmentRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BusAssignment>> GetByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Include(ba => ba.TourSchedule)
                .Include(ba => ba.Bus)
                .Include(ba => ba.Employee)
                .Where(ba => ba.TourScheduleId == tourScheduleId && ba.IsActive && !ba.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<BusAssignment>> GetByBusAsync(int busId)
        {
            return await _dbSet
                .Include(ba => ba.TourSchedule)
                .Include(ba => ba.Bus)
                .Include(ba => ba.Employee)
                .Where(ba => ba.BusId == busId && ba.IsActive && !ba.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<BusAssignment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(ba => ba.TourSchedule)
                .Include(ba => ba.Bus)
                .Include(ba => ba.Employee)
                .Where(ba => ba.AssignmentDate >= startDate && ba.AssignmentDate <= endDate && ba.IsActive && !ba.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<BusAssignment>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(ba => ba.TourSchedule)
                .Include(ba => ba.Bus)
                .Include(ba => ba.Employee)
                .Where(ba => ba.Status == status && ba.IsActive && !ba.IsDeleted)
                .ToListAsync();
        }
    }
} 