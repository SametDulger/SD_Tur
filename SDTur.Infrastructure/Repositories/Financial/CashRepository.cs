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
    public class CashRepository : Repository<Cash>, ICashRepository
    {
        public CashRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cash>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(c => c.TransactionDate >= startDate && c.TransactionDate <= endDate && c.IsActive && !c.IsDeleted)
                .OrderByDescending(c => c.TransactionDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cash>> GetByTransactionTypeAsync(string transactionType)
        {
            return await _dbSet
                .Where(c => c.TransactionType == transactionType && c.IsActive && !c.IsDeleted)
                .OrderByDescending(c => c.TransactionDate)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalBalanceAsync(DateTime date, string currency)
        {
            var income = await _dbSet
                .Where(c => c.TransactionDate <= date && c.Currency == currency && c.TransactionType == "Income" && c.IsActive && !c.IsDeleted)
                .SumAsync(c => c.Amount);
                
            var expense = await _dbSet
                .Where(c => c.TransactionDate <= date && c.Currency == currency && c.TransactionType == "Expense" && c.IsActive && !c.IsDeleted)
                .SumAsync(c => c.Amount);
                
            return income - expense;
        }

        public async Task<IEnumerable<Cash>> GetByCategoryAsync(string category)
        {
            return await _dbSet
                .Where(c => c.Category == category && c.IsActive && !c.IsDeleted)
                .OrderByDescending(c => c.TransactionDate)
                .ToListAsync();
        }
    }
} 