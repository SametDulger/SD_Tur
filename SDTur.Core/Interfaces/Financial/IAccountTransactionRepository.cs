using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Financial
{
    public interface IAccountTransactionRepository : IRepository<AccountTransaction>
    {
        Task<IEnumerable<AccountTransaction>> GetTransactionsByPassCompanyAsync(int passCompanyId);
        Task<IEnumerable<AccountTransaction>> GetTransactionsByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<AccountTransaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetAccountBalanceAsync(int accountId);
    }
} 