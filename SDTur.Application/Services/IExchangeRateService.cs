using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface IExchangeRateService
    {
        Task<IEnumerable<ExchangeRateDto>> GetAllAsync();
        Task<ExchangeRateDto> GetByIdAsync(int id);
        Task<ExchangeRateDto> CreateAsync(CreateExchangeRateDto createDto);
        Task<ExchangeRateDto> UpdateAsync(UpdateExchangeRateDto updateDto);
        Task DeleteAsync(int id);
        Task<ExchangeRateDto> GetLatestRateAsync(string fromCurrency, string toCurrency);
        Task<IEnumerable<ExchangeRateDto>> GetRatesByDateAsync(DateTime date);
        Task<IEnumerable<ExchangeRateDto>> GetRatesByCurrencyAsync(string currency);
    }
} 