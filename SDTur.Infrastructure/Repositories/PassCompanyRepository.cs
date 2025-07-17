using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class PassCompanyRepository : Repository<PassCompany>, IPassCompanyRepository
    {
        public PassCompanyRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PassCompany>> GetActivePassCompaniesAsync()
        {
            return await _dbSet.Where(pc => pc.IsActive).ToListAsync();
        }

        public async Task<PassCompany> GetPassCompanyWithAgreementsAsync(int id)
        {
            return await _dbSet
                .Include(pc => pc.PassAgreements)
                .FirstOrDefaultAsync(pc => pc.Id == id);
        }
    }
} 