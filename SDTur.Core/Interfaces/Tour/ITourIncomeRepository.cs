using System;
using SDTur.Core.Interfaces.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface ITourIncomeRepository : IRepository<TourIncome>
    {
        Task<IEnumerable<TourIncome>> GetIncomesByTourScheduleAsync(int tourScheduleId);
        Task<IEnumerable<TourIncome>> GetIncomesByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
} 