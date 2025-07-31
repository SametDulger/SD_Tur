using System;
using SDTur.Core.Interfaces.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Financial
{
    public interface IExchangeRateRepository : IRepository<ExchangeRate>
    {
        Task<ExchangeRate> GetLatestRateAsync(string fromCurrency, string toCurrency);
        Task<IEnumerable<ExchangeRate>> GetRatesByDateAsync(DateTime date);
        Task<IEnumerable<ExchangeRate>> GetRatesByCurrencyAsync(string currency);
        Task<decimal> GetRateAsync(string fromCurrency, string toCurrency, DateTime date);
    }
} 