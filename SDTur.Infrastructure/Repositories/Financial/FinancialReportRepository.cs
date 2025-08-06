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
    public class FinancialReportRepository : Repository<FinancialReport>, IFinancialReportRepository
    {
        public FinancialReportRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FinancialReport>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(fr => fr.ReportDate >= startDate && fr.ReportDate <= endDate && fr.IsActive)
                .OrderByDescending(fr => fr.ReportDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<FinancialReport>> GetByReportTypeAsync(string reportType)
        {
            return await _dbSet
                .Where(fr => fr.ReportType == reportType && fr.IsActive)
                .OrderByDescending(fr => fr.ReportDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<FinancialReport>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Where(fr => fr.Status == status && fr.IsActive)
                .OrderByDescending(fr => fr.ReportDate)
                .ToListAsync();
        }

        public async Task<FinancialReport?> GetFinancialReportWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(fr => fr.Employee)
                .FirstOrDefaultAsync(fr => fr.Id == id);
        }

        public async Task<FinancialReport?> GetLatestByTypeAsync(string reportType)
        {
            return await _dbSet
                .Where(fr => fr.ReportType == reportType && fr.IsActive)
                .OrderByDescending(fr => fr.ReportDate)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FinancialReport>> GetByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Where(fr => fr.EmployeeId == employeeId && fr.IsActive)
                .OrderByDescending(fr => fr.ReportDate)
                .ToListAsync();
        }
    }
} 