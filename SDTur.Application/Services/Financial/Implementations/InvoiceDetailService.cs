using AutoMapper;
using SDTur.Application.DTOs.Financial.InvoiceDetail;
using SDTur.Application.Services.Financial.Interfaces;
using SDTur.Core.Interfaces.Core;
using SDTur.Core.Entities.Financial;

namespace SDTur.Application.Services.Financial.Implementations
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InvoiceDetailDto>> GetAllAsync()
        {
            var invoiceDetails = await _unitOfWork.InvoiceDetails.GetAllAsync();
            return _mapper.Map<IEnumerable<InvoiceDetailDto>>(invoiceDetails);
        }

        public async Task<InvoiceDetailDto> GetByIdAsync(int id)
        {
            var invoiceDetail = await _unitOfWork.InvoiceDetails.GetByIdAsync(id);
            return _mapper.Map<InvoiceDetailDto>(invoiceDetail);
        }

        public async Task<IEnumerable<InvoiceDetailDto>> GetByInvoiceIdAsync(int invoiceId)
        {
            var invoiceDetails = await _unitOfWork.InvoiceDetails.GetByInvoiceIdAsync(invoiceId);
            return _mapper.Map<IEnumerable<InvoiceDetailDto>>(invoiceDetails);
        }

        public async Task<InvoiceDetailDto> CreateAsync(CreateInvoiceDetailDto createInvoiceDetailDto)
        {
            var invoiceDetail = _mapper.Map<InvoiceDetail>(createInvoiceDetailDto);
            await _unitOfWork.InvoiceDetails.AddAsync(invoiceDetail);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<InvoiceDetailDto>(invoiceDetail);
        }

        public async Task<InvoiceDetailDto> UpdateAsync(UpdateInvoiceDetailDto updateInvoiceDetailDto)
        {
            var existingInvoiceDetail = await _unitOfWork.InvoiceDetails.GetByIdAsync(updateInvoiceDetailDto.Id);
            if (existingInvoiceDetail == null)
                return null;

            _mapper.Map(updateInvoiceDetailDto, existingInvoiceDetail);
            await _unitOfWork.InvoiceDetails.UpdateAsync(existingInvoiceDetail);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<InvoiceDetailDto>(existingInvoiceDetail);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var invoiceDetail = await _unitOfWork.InvoiceDetails.GetByIdAsync(id);
            if (invoiceDetail == null)
                return false;

            await _unitOfWork.InvoiceDetails.DeleteAsync(invoiceDetail.Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
} 