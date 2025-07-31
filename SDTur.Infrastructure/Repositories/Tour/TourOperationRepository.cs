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
    public class TourOperationRepository : Repository<TourOperation>, ITourOperationRepository
    {
        public TourOperationRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TourOperation>> GetByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Employee)
                .Where(to => to.TourScheduleId == tourScheduleId && !to.IsDeleted)
                .OrderBy(to => to.OperationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourOperation>> GetByOperationTypeAsync(string operationType)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Employee)
                .Where(to => to.OperationType == operationType && !to.IsDeleted)
                .OrderBy(to => to.OperationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourOperation>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Employee)
                .Where(to => to.Status == status && !to.IsDeleted)
                .OrderBy(to => to.OperationDate)
                .ToListAsync();
        }

        public async Task<TourOperation> GetWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Bus)
                .Include(to => to.Employee)
                .Include(to => to.AssignedTickets)
                .FirstOrDefaultAsync(to => to.Id == id);
        }

        public async Task<IEnumerable<TourOperation>> GetOperationsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Employee)
                .Where(to => to.OperationDate >= startDate && to.OperationDate <= endDate && !to.IsDeleted)
                .OrderBy(to => to.OperationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourOperation>> GetOperationsByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Employee)
                .Where(to => to.EmployeeId == employeeId && !to.IsDeleted)
                .OrderByDescending(to => to.OperationDate)
                .ToListAsync();
        }
    }
} 