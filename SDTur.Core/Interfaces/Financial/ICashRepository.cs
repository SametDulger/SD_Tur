using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Financial
{
    public interface ICashRepository : IRepository<Cash>
    {
        Task<IEnumerable<Cash>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Cash>> GetByTransactionTypeAsync(string transactionType);
        Task<decimal> GetTotalBalanceAsync(DateTime date, string currency);
        Task<IEnumerable<Cash>> GetByCategoryAsync(string category);
    }
} 