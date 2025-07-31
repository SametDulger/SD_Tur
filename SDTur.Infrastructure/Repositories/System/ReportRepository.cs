using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.System;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.System
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Report>> GetByReportTypeAsync(string reportType)
        {
            return await _dbSet
                .Where(r => r.ReportType == reportType && r.IsActive)
                .OrderByDescending(r => r.ReportDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(r => r.ReportDate >= startDate && r.ReportDate <= endDate && r.IsActive)
                .OrderByDescending(r => r.ReportDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetByGeneratedByAsync(string generatedBy)
        {
            return await _dbSet
                .Where(r => r.GeneratedBy == generatedBy && r.IsActive)
                .OrderByDescending(r => r.ReportDate)
                .ToListAsync();
        }
    }
} 