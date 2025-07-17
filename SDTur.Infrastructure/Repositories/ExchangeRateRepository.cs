using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class ExchangeRateRepository : Repository<ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<ExchangeRate> GetLatestRateAsync(string fromCurrency, string toCurrency)
        {
            return await _dbSet
                .Where(er => er.FromCurrency == fromCurrency && er.ToCurrency == toCurrency)
                .OrderByDescending(er => er.RateDate)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ExchangeRate>> GetRatesByDateAsync(DateTime date)
        {
            return await _dbSet
                .Where(er => er.RateDate.Date == date.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<ExchangeRate>> GetRatesByCurrencyAsync(string currency)
        {
            return await _dbSet
                .Where(er => er.FromCurrency == currency || er.ToCurrency == currency)
                .OrderByDescending(er => er.RateDate)
                .ToListAsync();
        }

        public async Task<decimal> GetRateAsync(string fromCurrency, string toCurrency, DateTime date)
        {
            var rate = await _dbSet
                .Where(er => er.FromCurrency == fromCurrency && er.ToCurrency == toCurrency && er.RateDate.Date == date.Date)
                .FirstOrDefaultAsync();

            return rate?.Rate ?? 0;
        }
    }
} 