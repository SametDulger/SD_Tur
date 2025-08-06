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
    public class PassAgreementRepository : Repository<PassAgreement>, IPassAgreementRepository
    {
        public PassAgreementRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PassAgreement>> GetAgreementsByPassCompanyAsync(int passCompanyId)
        {
            return await _dbSet
                .Include(pa => pa.PassCompany)
                .Where(pa => pa.PassCompanyId == passCompanyId && pa.IsActive)
                .OrderByDescending(pa => pa.CreatedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<PassAgreement>> GetAgreementsByTourAsync(int tourId)
        {
            return await _dbSet
                .Include(pa => pa.PassCompany)
                .Where(pa => pa.TourId == tourId && pa.IsActive)
                .OrderByDescending(pa => pa.CreatedDate)
                .ToListAsync();
        }

        public async Task<PassAgreement?> GetPassAgreementWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(pa => pa.PassCompany)
                .Include(pa => pa.Tour)
                .FirstOrDefaultAsync(pa => pa.Id == id);
        }

        public async Task<PassAgreement?> GetAgreementByCompanyAndTourAsync(int passCompanyId, int tourId)
        {
            return await _dbSet
                .Include(pa => pa.PassCompany)
                .FirstOrDefaultAsync(pa => pa.PassCompanyId == passCompanyId && pa.TourId == tourId && pa.IsActive);
        }

        public async Task<IEnumerable<PassAgreement>> GetActiveAgreementsAsync()
        {
            return await _dbSet
                .Include(pa => pa.PassCompany)
                .Where(pa => pa.IsActive)
                .OrderByDescending(pa => pa.CreatedDate)
                .ToListAsync();
        }
    }
} 