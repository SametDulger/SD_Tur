using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class TourOperationRepository : Repository<TourOperation>, ITourOperationRepository
    {
        public TourOperationRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TourOperation>> GetByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Where(to => to.TourScheduleId == tourScheduleId)
                .OrderByDescending(to => to.OperationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourOperation>> GetByOperationTypeAsync(string operationType)
        {
            return await _dbSet
                .Where(to => to.OperationType == operationType)
                .OrderByDescending(to => to.OperationDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourOperation>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Where(to => to.Status == status)
                .OrderByDescending(to => to.OperationDate)
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
    }
} 