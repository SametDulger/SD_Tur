using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
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
                .ThenInclude(id => id.TourSchedule)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByPassCompanyAsync(int passCompanyId)
        {
            return await _dbSet
                .Include(i => i.PassCompany)
                .Include(i => i.InvoiceDetails)
                .Where(i => i.PassCompanyId == passCompanyId)
                .OrderByDescending(i => i.InvoiceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Include(i => i.PassCompany)
                .Include(i => i.InvoiceDetails)
                .Where(i => i.InvoiceDate >= startDate && i.InvoiceDate <= endDate)
                .OrderByDescending(i => i.InvoiceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByStatusAsync(string status)
        {
            return await _dbSet
                .Include(i => i.PassCompany)
                .Include(i => i.InvoiceDetails)
                .Where(i => i.Status == status)
                .OrderByDescending(i => i.InvoiceDate)
                .ToListAsync();
        }
    }
} 