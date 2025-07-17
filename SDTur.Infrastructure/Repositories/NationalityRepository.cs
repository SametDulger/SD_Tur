using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class NationalityRepository : Repository<Nationality>, INationalityRepository
    {
        public NationalityRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Nationality>> GetActiveNationalitiesAsync()
        {
            return await _dbSet.Where(n => n.IsActive).OrderBy(n => n.Name).ToListAsync();
        }
    }
} 