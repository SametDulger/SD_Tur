using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Financial
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<Invoice?> GetInvoiceWithDetailsAsync(int id);
        Task<IEnumerable<Invoice>> GetInvoicesByPassCompanyAsync(int passCompanyId);
        Task<IEnumerable<Invoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Invoice>> GetInvoicesByStatusAsync(string status);
    }
} 