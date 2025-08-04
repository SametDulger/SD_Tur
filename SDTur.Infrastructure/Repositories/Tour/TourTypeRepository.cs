using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.Tour;
using SDTur.Core.Interfaces.Tour;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.Tour
{
    public class TourTypeRepository : Repository<TourType>, ITourTypeRepository
    {
        public TourTypeRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TourType>> GetActiveTourTypesAsync()
        {
            return await _context.TourTypes
                .Where(tt => tt.IsActive)
                .OrderBy(tt => tt.Name)
                .ToListAsync();
        }
    }
} 