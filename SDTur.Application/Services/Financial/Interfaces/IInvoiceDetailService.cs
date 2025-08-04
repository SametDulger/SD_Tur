using SDTur.Application.DTOs.Financial.InvoiceDetail;

namespace SDTur.Application.Services.Financial.Interfaces
{
    public interface IInvoiceDetailService
    {
        Task<IEnumerable<InvoiceDetailDto>> GetAllAsync();
        Task<InvoiceDetailDto?> GetByIdAsync(int id);
        Task<IEnumerable<InvoiceDetailDto>> GetByInvoiceIdAsync(int invoiceId);
        Task<InvoiceDetailDto?> CreateAsync(CreateInvoiceDetailDto createDto);
        Task<InvoiceDetailDto?> UpdateAsync(UpdateInvoiceDetailDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
} 