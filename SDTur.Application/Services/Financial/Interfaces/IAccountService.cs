using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Financial.Account;

namespace SDTur.Application.Services.Financial.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAsync();
        Task<IEnumerable<AccountDto>> GetActiveAsync();
        Task<AccountDto> GetByIdAsync(int id);
        Task<AccountDto> GetWithTransactionsAsync(int id);
        Task<IEnumerable<AccountDto>> GetByAccountTypeAsync(string accountType);
        Task<decimal> GetAccountBalanceAsync(int accountId);
        Task<AccountDto> CreateAsync(CreateAccountDto createDto);
        Task<AccountDto> UpdateAsync(UpdateAccountDto updateDto);
        Task DeleteAsync(int id);
    }
} 