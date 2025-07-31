using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Master
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<IEnumerable<Currency>> GetActiveCurrenciesAsync();
    }
} 