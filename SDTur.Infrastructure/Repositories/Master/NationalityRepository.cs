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
    public class NationalityRepository : Repository<Nationality>, INationalityRepository
    {
        public NationalityRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Nationality>> GetActiveNationalitiesAsync()
        {
            return await _dbSet
                .Where(n => n.IsActive)
                .OrderBy(n => n.Name)
                .ToListAsync();
        }
    }
} 