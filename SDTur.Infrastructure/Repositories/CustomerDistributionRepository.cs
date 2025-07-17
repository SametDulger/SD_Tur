using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class CustomerDistributionRepository : Repository<CustomerDistribution>, ICustomerDistributionRepository
    {
        public CustomerDistributionRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CustomerDistribution>> GetByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Include(cd => cd.TourSchedule)
                .Include(cd => cd.Bus)
                .Include(cd => cd.Ticket)
                .Include(cd => cd.Employee)
                .Where(cd => cd.TourScheduleId == tourScheduleId && !cd.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomerDistribution>> GetByBusAsync(int busId)
        {
            return await _dbSet
                .Include(cd => cd.TourSchedule)
                .Include(cd => cd.Bus)
                .Include(cd => cd.Ticket)
                .Include(cd => cd.Employee)
                .Where(cd => cd.BusId == busId && !cd.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomerDistribution>> GetByTicketAsync(int ticketId)
        {
            return await _dbSet
                .Include(cd => cd.TourSchedule)
                .Include(cd => cd.Bus)
                .Include(cd => cd.Ticket)
                .Include(cd => cd.Employee)
                .Where(cd => cd.TicketId == ticketId && !cd.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomerDistribution>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(cd => cd.TourSchedule)
                .Include(cd => cd.Bus)
                .Include(cd => cd.Ticket)
                .Include(cd => cd.Employee)
                .Where(cd => cd.DistributionDate >= startDate && cd.DistributionDate <= endDate && !cd.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomerDistribution>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(cd => cd.TourSchedule)
                .Include(cd => cd.Bus)
                .Include(cd => cd.Ticket)
                .Include(cd => cd.Employee)
                .Where(cd => cd.Status == status && !cd.IsDeleted)
                .ToListAsync();
        }
    }
} 