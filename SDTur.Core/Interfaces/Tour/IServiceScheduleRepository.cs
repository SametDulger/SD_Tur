using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface IServiceScheduleRepository : IRepository<ServiceSchedule>
    {
        Task<IEnumerable<ServiceSchedule>> GetSchedulesByRegionAsync(int regionId);
        Task<IEnumerable<ServiceSchedule>> GetSchedulesByDateAsync(DateTime date);
        Task<IEnumerable<ServiceSchedule>> GetActiveSchedulesAsync();
    }
} 