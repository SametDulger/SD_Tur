using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Financial.Cash;

namespace SDTur.Application.Services.Financial.Interfaces
{
    public interface ICashService
    {
        Task<IEnumerable<CashDto>> GetAllAsync();
        Task<CashDto> GetByIdAsync(int id);
        Task<IEnumerable<CashDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<CashDto>> GetByTransactionTypeAsync(string transactionType);
        Task<decimal> GetTotalBalanceAsync(DateTime date, string currency);
        Task<CashDto> CreateAsync(CreateCashDto createDto);
        Task<CashDto> UpdateAsync(UpdateCashDto updateDto);
        Task DeleteAsync(int id);
    }
} 