using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Financial.AccountTransaction;

namespace SDTur.Application.Services.Financial.Interfaces
{
    public interface IAccountTransactionService
    {
        Task<IEnumerable<AccountTransactionDto>> GetAllAsync();
        Task<AccountTransactionDto> GetByIdAsync(int id);
        Task<AccountTransactionDto> CreateAsync(CreateAccountTransactionDto createDto);
        Task<AccountTransactionDto> UpdateAsync(UpdateAccountTransactionDto updateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<AccountTransactionDto>> GetByPassCompanyAsync(int passCompanyId);
        Task<IEnumerable<AccountTransactionDto>> GetByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<AccountTransactionDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
} 