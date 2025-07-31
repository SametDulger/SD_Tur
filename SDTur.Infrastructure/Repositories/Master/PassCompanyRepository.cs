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
    public class PassCompanyRepository : Repository<PassCompany>, IPassCompanyRepository
    {
        public PassCompanyRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PassCompany>> GetActivePassCompaniesAsync()
        {
            return await _dbSet
                .Where(pc => pc.IsActive)
                .OrderBy(pc => pc.Name)
                .ToListAsync();
        }

        public async Task<PassCompany> GetPassCompanyWithAgreementsAsync(int id)
        {
            return await _dbSet
                .Include(pc => pc.PassAgreements)
                .FirstOrDefaultAsync(pc => pc.Id == id);
        }
    }
} 