using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface ITourRepository : IRepository<Tour>
    {
        Task<IEnumerable<Tour>> GetActiveToursAsync();
        Task<Tour> GetTourWithSchedulesAsync(int id);
    }
} 