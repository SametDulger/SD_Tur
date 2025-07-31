using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Master;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.Master
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