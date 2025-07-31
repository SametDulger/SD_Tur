using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Financial;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.Financial
{
    public class InvoiceDetailRepository : Repository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InvoiceDetail>> GetByInvoiceIdAsync(int invoiceId)
        {
            return await _dbSet
                .Include(id => id.Invoice)
                .Include(id => id.TourSchedule)
                .Where(id => id.InvoiceId == invoiceId)
                .ToListAsync();
        }

        public override async Task<InvoiceDetail> UpdateAsync(InvoiceDetail invoiceDetail)
        {
            invoiceDetail.UpdatedDate = DateTime.UtcNow;
            _dbSet.Update(invoiceDetail);
            return await Task.FromResult(invoiceDetail);
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.UpdatedDate = DateTime.UtcNow;
                _dbSet.Update(entity);
            }
        }
    }
} 