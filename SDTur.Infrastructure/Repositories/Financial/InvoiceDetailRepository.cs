using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;
using SDTur.Core.Interfaces.Financial;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.Financial
{
    public class InvoiceDetailRepository : Repository<InvoiceDetail>, IInvoiceDetailRepository
    {
        private readonly ILogger<InvoiceDetailRepository>? _logger;

        public InvoiceDetailRepository(SDTurDbContext context, ILogger<InvoiceDetailRepository>? logger = null)
            : base(context)
        {
            _logger = logger;
        }

        public async Task<InvoiceDetail?> GetInvoiceDetailWithInvoiceAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Invoice)
                .FirstOrDefaultAsync(x => x.Id == id);
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