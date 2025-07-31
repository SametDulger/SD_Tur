using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Tour
{
    public interface ITourRepository : IRepository<SDTur.Core.Entities.Tour.Tour>
    {
        Task<IEnumerable<SDTur.Core.Entities.Tour.Tour>> GetActiveToursAsync();
        Task<SDTur.Core.Entities.Tour.Tour> GetTourWithSchedulesAsync(int id);
    }
} 