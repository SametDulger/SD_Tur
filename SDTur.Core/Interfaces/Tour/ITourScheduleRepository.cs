using System;
using SDTur.Core.Interfaces.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface ITourScheduleRepository : IRepository<TourSchedule>
    {
        Task<TourSchedule> GetTourScheduleWithDetailsAsync(int id);
        Task<IEnumerable<TourSchedule>> GetTourSchedulesByTourAsync(int tourId);
        Task<IEnumerable<TourSchedule>> GetTourSchedulesByDateAsync(DateTime date);
    }
} 