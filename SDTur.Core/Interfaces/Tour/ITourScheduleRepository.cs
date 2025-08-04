using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface ITourScheduleRepository : IRepository<TourSchedule>
    {
        Task<IEnumerable<TourSchedule>> GetSchedulesByTourAsync(int tourId);
        Task<TourSchedule?> GetScheduleWithDetailsAsync(int id);
        Task<IEnumerable<TourSchedule>> GetSchedulesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<TourSchedule>> GetActiveSchedulesAsync();
    }
} 