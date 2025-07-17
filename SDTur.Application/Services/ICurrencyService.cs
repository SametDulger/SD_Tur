using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyDto>> GetAllAsync();
        Task<IEnumerable<CurrencyDto>> GetActiveAsync();
        Task<CurrencyDto> GetByIdAsync(int id);
        Task<CurrencyDto> CreateAsync(CreateCurrencyDto createDto);
        Task<CurrencyDto> UpdateAsync(UpdateCurrencyDto updateDto);
        Task DeleteAsync(int id);
    }
} 