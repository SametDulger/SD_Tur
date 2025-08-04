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

        public async Task<InvoiceDetailDto?> GetByIdAsync(int id)
        {
            var invoiceDetail = await _unitOfWork.InvoiceDetails.GetByIdAsync(id);
            return invoiceDetail != null ? _mapper.Map<InvoiceDetailDto>(invoiceDetail) : null;
        }

        public async Task<IEnumerable<InvoiceDetailDto>> GetByInvoiceIdAsync(int invoiceId)
        {
            try
            {
                var invoiceDetails = await _unitOfWork.InvoiceDetails.GetAllAsync();
                var filteredDetails = invoiceDetails.Where(id => id.InvoiceId == invoiceId);
                return _mapper.Map<IEnumerable<InvoiceDetailDto>>(filteredDetails);
            }
            catch
            {
                throw;
            }
        }

        public async Task<InvoiceDetailDto?> CreateAsync(CreateInvoiceDetailDto createDto)
        {
            var entity = _mapper.Map<InvoiceDetail>(createDto);
            var created = await _unitOfWork.InvoiceDetails.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<InvoiceDetailDto>(created);
        }

        public async Task<InvoiceDetailDto?> UpdateAsync(UpdateInvoiceDetailDto updateDto)
        {
            var entity = await _unitOfWork.InvoiceDetails.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.InvoiceDetails.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<InvoiceDetailDto>(updated);
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