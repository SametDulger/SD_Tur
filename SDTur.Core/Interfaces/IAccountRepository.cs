using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> GetActiveAccountsAsync();
        Task<Account> GetAccountWithTransactionsAsync(int id);
        Task<IEnumerable<Account>> GetByAccountTypeAsync(string accountType);
        Task<decimal> GetAccountBalanceAsync(int accountId);
    }
} 