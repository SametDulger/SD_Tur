using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Financial.Invoice;

namespace SDTur.Application.Services.Financial.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDto>> GetAllAsync();
        Task<InvoiceDto?> GetByIdAsync(int id);
        Task<InvoiceDto?> GetWithDetailsAsync(int id);
        Task<InvoiceDto?> CreateAsync(CreateInvoiceDto createDto);
        Task<InvoiceDto?> UpdateAsync(UpdateInvoiceDto updateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<InvoiceDto>> GetByPassCompanyAsync(int passCompanyId);
        Task<IEnumerable<InvoiceDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<InvoiceDto>> GetByStatusAsync(string status);
    }
} 