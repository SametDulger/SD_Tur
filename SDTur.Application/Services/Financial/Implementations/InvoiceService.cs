using AutoMapper;
using SDTur.Application.DTOs.Financial.Invoice;
using SDTur.Application.Services.Financial.Interfaces;
using SDTur.Core.Entities.Financial;
using SDTur.Core.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SDTur.Application.Services.Financial.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllAsync()
        {
            var invoices = await _unitOfWork.Invoices.GetAllAsync();
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<InvoiceDto?> GetByIdAsync(int id)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
            return invoice != null ? _mapper.Map<InvoiceDto>(invoice) : null;
        }

        public async Task<InvoiceDto?> GetWithDetailsAsync(int id)
        {
            var invoice = await _unitOfWork.Invoices.GetInvoiceWithDetailsAsync(id);
            return invoice != null ? _mapper.Map<InvoiceDto>(invoice) : null;
        }

        public async Task<InvoiceDto?> CreateAsync(CreateInvoiceDto createDto)
        {
            var entity = _mapper.Map<Invoice>(createDto);
            var created = await _unitOfWork.Invoices.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<InvoiceDto>(created);
        }

        public async Task<InvoiceDto?> UpdateAsync(UpdateInvoiceDto updateDto)
        {
            var entity = await _unitOfWork.Invoices.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.Invoices.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<InvoiceDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Invoices.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<InvoiceDto>> GetByPassCompanyAsync(int passCompanyId)
        {
            var invoices = await _unitOfWork.Invoices.GetInvoicesByPassCompanyAsync(passCompanyId);
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<IEnumerable<InvoiceDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var invoices = await _unitOfWork.Invoices.GetInvoicesByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<IEnumerable<InvoiceDto>> GetByStatusAsync(string status)
        {
            var invoices = await _unitOfWork.Invoices.GetInvoicesByStatusAsync(status);
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }
    }
} 