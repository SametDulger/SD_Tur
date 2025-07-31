using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Financial;

namespace SDTur.Core.Interfaces.Financial
{
    public interface IInvoiceDetailRepository
    {
        Task<IEnumerable<InvoiceDetail>> GetAllAsync();
        Task<InvoiceDetail> GetByIdAsync(int id);
        Task<IEnumerable<InvoiceDetail>> GetByInvoiceIdAsync(int invoiceId);
        Task<InvoiceDetail> AddAsync(InvoiceDetail invoiceDetail);
        Task<InvoiceDetail> UpdateAsync(InvoiceDetail invoiceDetail);
        Task DeleteAsync(int id);
    }
} 