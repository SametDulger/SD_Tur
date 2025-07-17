using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Currency>> GetActiveCurrenciesAsync()
        {
            return await _dbSet.Where(c => c.IsActive).OrderBy(c => c.Name).ToListAsync();
        }
    }
} 