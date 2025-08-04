using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Financial
{
    public interface IInvoiceDetailRepository : IRepository<InvoiceDetail>
    {
        Task<InvoiceDetail?> GetInvoiceDetailWithInvoiceAsync(int id);
    }
} 