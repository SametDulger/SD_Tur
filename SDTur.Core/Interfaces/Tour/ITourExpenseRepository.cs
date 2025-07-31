using System;
using SDTur.Core.Interfaces.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface ITourExpenseRepository : IRepository<TourExpense>
    {
        Task<IEnumerable<TourExpense>> GetExpensesByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<TourExpense>> GetExpensesByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
} 