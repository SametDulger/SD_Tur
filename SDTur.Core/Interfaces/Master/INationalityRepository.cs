using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Master
{
    public interface INationalityRepository : IRepository<Nationality>
    {
        Task<IEnumerable<Nationality>> GetActiveNationalitiesAsync();
    }
} 