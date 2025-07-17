using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
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
                .Where(ba => ba.TourScheduleId == tourScheduleId && !ba.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<BusAssignment>> GetByBusAsync(int busId)
        {
            return await _dbSet
                .Include(ba => ba.TourSchedule)
                .Include(ba => ba.Bus)
                .Include(ba => ba.Employee)
                .Where(ba => ba.BusId == busId && !ba.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<BusAssignment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(ba => ba.TourSchedule)
                .Include(ba => ba.Bus)
                .Include(ba => ba.Employee)
                .Where(ba => ba.AssignmentDate >= startDate && ba.AssignmentDate <= endDate && !ba.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<BusAssignment>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(ba => ba.TourSchedule)
                .Include(ba => ba.Bus)
                .Include(ba => ba.Employee)
                .Where(ba => ba.Status == status && !ba.IsDeleted)
                .ToListAsync();
        }
    }
} 