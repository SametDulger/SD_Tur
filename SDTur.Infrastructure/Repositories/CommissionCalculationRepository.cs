using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class CommissionCalculationRepository : Repository<CommissionCalculation>, ICommissionCalculationRepository
    {
        public CommissionCalculationRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CommissionCalculation>> GetByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Include(cc => cc.Ticket)
                .Include(cc => cc.Employee)
                .Where(cc => cc.EmployeeId == employeeId && !cc.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<CommissionCalculation>> GetByTicketAsync(int ticketId)
        {
            return await _dbSet
                .Include(cc => cc.Ticket)
                .Include(cc => cc.Employee)
                .Where(cc => cc.TicketId == ticketId && !cc.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<CommissionCalculation>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(cc => cc.Ticket)
                .Include(cc => cc.Employee)
                .Where(cc => cc.CalculationDate >= startDate && cc.CalculationDate <= endDate && !cc.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<CommissionCalculation>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(cc => cc.Ticket)
                .Include(cc => cc.Employee)
                .Where(cc => cc.Status == status && !cc.IsDeleted)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalCommissionByEmployeeAsync(int employeeId, DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(cc => cc.EmployeeId == employeeId && 
                            cc.CalculationDate >= startDate && 
                            cc.CalculationDate <= endDate && 
                            !cc.IsDeleted)
                .SumAsync(cc => cc.CommissionAmount);
        }
    }
} 