using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Master.Currency;

namespace SDTur.Application.Services.Master.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyDto>> GetAllAsync();
        Task<IEnumerable<CurrencyDto>> GetActiveAsync();
        Task<CurrencyDto?> GetByIdAsync(int id);
        Task<CurrencyDto?> CreateAsync(CreateCurrencyDto createDto);
        Task<CurrencyDto?> UpdateAsync(UpdateCurrencyDto updateDto);
        Task DeleteAsync(int id);
    }
} 