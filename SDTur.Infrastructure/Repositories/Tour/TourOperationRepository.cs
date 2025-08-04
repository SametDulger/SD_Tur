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
                .Where(to => to.TourScheduleId == tourScheduleId && to.IsActive && !to.IsDeleted)
                .OrderBy(to => to.OperationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourOperation>> GetByOperationTypeAsync(string operationType)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Employee)
                .Where(to => to.OperationType == operationType && to.IsActive && !to.IsDeleted)
                .OrderBy(to => to.OperationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourOperation>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Employee)
                .Where(to => to.Status == status && to.IsActive && !to.IsDeleted)
                .OrderBy(to => to.OperationDate)
                .ToListAsync();
        }

        public async Task<TourOperation?> GetTourOperationWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Bus)
                .Include(to => to.Employee)
                .FirstOrDefaultAsync(to => to.Id == id && to.IsActive && !to.IsDeleted);
        }

        public async Task<IEnumerable<TourOperation>> GetOperationsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Employee)
                .Where(to => to.OperationDate >= startDate && to.OperationDate <= endDate && to.IsActive && !to.IsDeleted)
                .OrderBy(to => to.OperationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourOperation>> GetOperationsByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Employee)
                .Where(to => to.EmployeeId == employeeId && to.IsActive && !to.IsDeleted)
                .OrderByDescending(to => to.OperationDate)
                .ToListAsync();
        }

        public async Task<TourOperation?> GetWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(to => to.TourSchedule)
                .Include(to => to.Bus)
                .Include(to => to.Employee)
                .FirstOrDefaultAsync(to => to.Id == id && to.IsActive && !to.IsDeleted);
        }
    }
} 