using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;
using SDTur.Infrastructure.Data;

namespace SDTur.Infrastructure.Repositories
{
    public class TourExpenseRepository : Repository<TourExpense>, ITourExpenseRepository
    {
        public TourExpenseRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TourExpense>> GetExpensesByTourScheduleAsync(int tourScheduleId)
        {
            return await _dbSet
                .Where(te => te.TourScheduleId == tourScheduleId)
                .OrderBy(te => te.ExpenseDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TourExpense>> GetExpensesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(te => te.ExpenseDate >= startDate && te.ExpenseDate <= endDate)
                .OrderBy(te => te.ExpenseDate)
                .ToListAsync();
        }
    }
} 