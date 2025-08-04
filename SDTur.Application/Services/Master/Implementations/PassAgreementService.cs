using AutoMapper;
using SDTur.Application.DTOs.Master.PassAgreement;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.Application.Services.Master.Implementations
{
    public class PassAgreementService : IPassAgreementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PassAgreementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PassAgreementDto>> GetAllAsync()
        {
            var passAgreements = await _unitOfWork.PassAgreements.GetAllAsync();
            return _mapper.Map<IEnumerable<PassAgreementDto>>(passAgreements);
        }

        public async Task<PassAgreementDto?> GetByIdAsync(int id)
        {
            var passAgreement = await _unitOfWork.PassAgreements.GetByIdAsync(id);
            return passAgreement != null ? _mapper.Map<PassAgreementDto>(passAgreement) : null;
        }

        public async Task<PassAgreementDto?> CreateAsync(CreatePassAgreementDto createDto)
        {
            var entity = _mapper.Map<PassAgreement>(createDto);
            var created = await _unitOfWork.PassAgreements.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PassAgreementDto>(created);
        }

        public async Task<PassAgreementDto?> UpdateAsync(UpdatePassAgreementDto updateDto)
        {
            var entity = await _unitOfWork.PassAgreements.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.PassAgreements.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PassAgreementDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.PassAgreements.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<PassAgreementDto>> GetByPassCompanyAsync(int passCompanyId)
        {
            var passAgreements = await _unitOfWork.PassAgreements.GetAgreementsByPassCompanyAsync(passCompanyId);
            return _mapper.Map<IEnumerable<PassAgreementDto>>(passAgreements);
        }

        public async Task<IEnumerable<PassAgreementDto>> GetByTourAsync(int tourId)
        {
            var passAgreements = await _unitOfWork.PassAgreements.GetAgreementsByTourAsync(tourId);
            return _mapper.Map<IEnumerable<PassAgreementDto>>(passAgreements);
        }
    }
} 