using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Account>> GetActiveAccountsAsync()
        {
            return await _dbSet
                .Where(a => a.IsActive)
                .OrderBy(a => a.AccountName)
                .ToListAsync();
        }

        public async Task<Account> GetAccountWithTransactionsAsync(int id)
        {
            return await _dbSet
                .Include(a => a.AccountTransactions)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Account>> GetByAccountTypeAsync(string accountType)
        {
            return await _dbSet
                .Where(a => a.AccountType == accountType && a.IsActive)
                .OrderBy(a => a.AccountName)
                .ToListAsync();
        }

        public async Task<decimal> GetAccountBalanceAsync(int accountId)
        {
            var account = await _dbSet
                .Include(a => a.AccountTransactions)
                .FirstOrDefaultAsync(a => a.Id == accountId);
                
            if (account == null)
                return 0;
                
            var debit = account.AccountTransactions
                .Where(at => at.TransactionType == "Debit")
                .Sum(at => at.Amount);
                
            var credit = account.AccountTransactions
                .Where(at => at.TransactionType == "Credit")
                .Sum(at => at.Amount);
                
            return credit - debit;
        }
    }
} 