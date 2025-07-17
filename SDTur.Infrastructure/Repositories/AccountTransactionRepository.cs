using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class AccountTransactionRepository : Repository<AccountTransaction>, IAccountTransactionRepository
    {
        public AccountTransactionRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AccountTransaction>> GetTransactionsByPassCompanyAsync(int passCompanyId)
        {
            // Since AccountTransaction doesn't have PassCompanyId, we'll return empty for now
            // This method should be removed or the entity should be updated
            return new List<AccountTransaction>();
        }

        public async Task<IEnumerable<AccountTransaction>> GetTransactionsByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Include(at => at.Account)
                .Include(at => at.TourSchedule)
                .Include(at => at.Ticket)
                .Where(at => at.TourScheduleId == tourScheduleId)
                .OrderByDescending(at => at.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<AccountTransaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(at => at.Account)
                .Include(at => at.TourSchedule)
                .Include(at => at.Ticket)
                .Where(at => at.TransactionDate >= startDate && at.TransactionDate <= endDate)
                .OrderByDescending(at => at.TransactionDate)
                .ToListAsync();
        }

        public async Task<decimal> GetBalanceByPassCompanyAsync(int passCompanyId)
        {
            // Since AccountTransaction doesn't have PassCompanyId, we'll return 0 for now
            // This method should be removed or the entity should be updated
            return 0;
        }
    }
} 