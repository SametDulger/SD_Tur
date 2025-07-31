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
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<Invoice> GetInvoiceWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(i => i.PassCompany)
                .Include(i => i.InvoiceDetails)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByPassCompanyAsync(int passCompanyId)
        {
            return await _dbSet
                .Include(i => i.PassCompany)
                .Where(i => i.PassCompanyId == passCompanyId && i.IsActive)
                .OrderByDescending(i => i.InvoiceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(i => i.PassCompany)
                .Where(i => i.InvoiceDate >= startDate && i.InvoiceDate <= endDate && i.IsActive)
                .OrderByDescending(i => i.InvoiceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByStatusAsync(string status)
        {
            return await _dbSet
                .Include(i => i.PassCompany)
                .Where(i => i.Status == status && i.IsActive)
                .OrderByDescending(i => i.InvoiceDate)
                .ToListAsync();
        }
    }
} 