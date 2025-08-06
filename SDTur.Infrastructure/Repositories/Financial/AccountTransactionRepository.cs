using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Financial;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.Financial
{
    public class AccountTransactionRepository : Repository<AccountTransaction>, IAccountTransactionRepository
    {
        public AccountTransactionRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AccountTransaction>> GetTransactionsByPassCompanyAsync(int passCompanyId)
        {
            return await _dbSet
                .Include(at => at.Account)
                .Include(at => at.PassCompany)
                .Include(at => at.TourSchedule)
                .Include(at => at.Ticket)
                .Where(at => at.PassCompanyId == passCompanyId && at.IsActive && !at.IsDeleted)
                .OrderByDescending(at => at.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<AccountTransaction>> GetTransactionsByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Include(at => at.Account)
                .Include(at => at.TourSchedule)
                .Include(at => at.Ticket)
                .Where(at => at.TourScheduleId == tourScheduleId && at.IsActive && !at.IsDeleted)
                .OrderByDescending(at => at.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<AccountTransaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(at => at.Account)
                .Include(at => at.TourSchedule)
                .Include(at => at.Ticket)
                .Where(at => at.TransactionDate >= startDate && at.TransactionDate <= endDate && at.IsActive && !at.IsDeleted)
                .OrderByDescending(at => at.TransactionDate)
                .ToListAsync();
        }

        public async Task<decimal> GetBalanceByPassCompanyAsync(int passCompanyId)
        {
            return await _dbSet
                .Where(at => at.PassCompanyId == passCompanyId && at.IsActive && !at.IsDeleted)
                .SumAsync(at => at.TransactionType == "Credit" ? at.Amount : -at.Amount);
        }

        public async Task<decimal> GetAccountBalanceAsync(int accountId)
        {
            return await _dbSet
                .Where(at => at.AccountId == accountId && at.IsActive && !at.IsDeleted)
                .SumAsync(at => at.TransactionType == "Credit" ? at.Amount : -at.Amount);
        }
    }
} 