using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class PassAgreementRepository : Repository<PassAgreement>, IPassAgreementRepository
    {
        public PassAgreementRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PassAgreement>> GetAgreementsByPassCompanyAsync(int passCompanyId)
        {
            return await _dbSet
                .Include(pa => pa.Tour)
                .Where(pa => pa.PassCompanyId == passCompanyId && pa.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<PassAgreement>> GetAgreementsByTourAsync(int tourId)
        {
            return await _dbSet
                .Include(pa => pa.PassCompany)
                .Where(pa => pa.TourId == tourId && pa.IsActive)
                .ToListAsync();
        }

        public async Task<PassAgreement> GetAgreementByCompanyAndTourAsync(int passCompanyId, int tourId)
        {
            return await _dbSet
                .Include(pa => pa.PassCompany)
                .Include(pa => pa.Tour)
                .FirstOrDefaultAsync(pa => pa.PassCompanyId == passCompanyId && pa.TourId == tourId && pa.IsActive);
        }
    }
} 