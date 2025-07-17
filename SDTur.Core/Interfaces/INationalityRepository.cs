using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface INationalityRepository : IRepository<Nationality>
    {
        Task<IEnumerable<Nationality>> GetActiveNationalitiesAsync();
    }
} 