using SDTur.Application.DTOs.Financial.InvoiceDetail;

namespace SDTur.Application.Services.Financial.Interfaces
{
    public interface IInvoiceDetailService
    {
        Task<IEnumerable<InvoiceDetailDto>> GetAllAsync();
        Task<InvoiceDetailDto> GetByIdAsync(int id);
        Task<IEnumerable<InvoiceDetailDto>> GetByInvoiceIdAsync(int invoiceId);
        Task<InvoiceDetailDto> CreateAsync(CreateInvoiceDetailDto createInvoiceDetailDto);
        Task<InvoiceDetailDto> UpdateAsync(UpdateInvoiceDetailDto updateInvoiceDetailDto);
        Task<bool> DeleteAsync(int id);
    }
} 