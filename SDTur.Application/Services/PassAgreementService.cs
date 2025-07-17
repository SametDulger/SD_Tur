using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
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

        public async Task<PassAgreementDto> GetByIdAsync(int id)
        {
            var passAgreement = await _unitOfWork.PassAgreements.GetByIdAsync(id);
            return _mapper.Map<PassAgreementDto>(passAgreement);
        }

        public async Task<PassAgreementDto> CreateAsync(CreatePassAgreementDto createDto)
        {
            var passAgreement = _mapper.Map<PassAgreement>(createDto);
            passAgreement.IsActive = true;
            
            await _unitOfWork.PassAgreements.AddAsync(passAgreement);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<PassAgreementDto>(passAgreement);
        }

        public async Task<PassAgreementDto> UpdateAsync(UpdatePassAgreementDto updateDto)
        {
            var passAgreement = await _unitOfWork.PassAgreements.GetByIdAsync(updateDto.Id);
            if (passAgreement == null)
                throw new ArgumentException("Pas anlaşması bulunamadı");

            _mapper.Map(updateDto, passAgreement);
            
            await _unitOfWork.PassAgreements.UpdateAsync(passAgreement);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<PassAgreementDto>(passAgreement);
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