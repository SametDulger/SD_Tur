using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Task<IEnumerable<Currency>> GetActiveCurrenciesAsync();
    }
} 