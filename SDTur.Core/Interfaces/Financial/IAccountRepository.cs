using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Financial
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> GetActiveAccountsAsync();
        Task<Account?> GetAccountWithTransactionsAsync(int id);
        Task<IEnumerable<Account>> GetByAccountTypeAsync(string accountType);
        Task<decimal> GetAccountBalanceAsync(int accountId);
    }
} 