using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<Invoice> GetInvoiceWithDetailsAsync(int id);
        Task<IEnumerable<Invoice>> GetInvoicesByPassCompanyAsync(int passCompanyId);
        Task<IEnumerable<Invoice>> GetInvoicesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Invoice>> GetInvoicesByStatusAsync(string status);
    }
} 