using AutoMapper;
using SDTur.Application.DTOs.Master.PassCompany;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.Application.Services.Master.Implementations
{
    public class PassCompanyService : IPassCompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PassCompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PassCompanyDto>> GetAllAsync()
        {
            var passCompanies = await _unitOfWork.PassCompanies.GetAllAsync();
            return _mapper.Map<IEnumerable<PassCompanyDto>>(passCompanies);
        }

        public async Task<PassCompanyDto?> GetByIdAsync(int id)
        {
            var passCompany = await _unitOfWork.PassCompanies.GetByIdAsync(id);
            return passCompany != null ? _mapper.Map<PassCompanyDto>(passCompany) : null;
        }

        public async Task<PassCompanyDto?> CreateAsync(CreatePassCompanyDto createDto)
        {
            var entity = _mapper.Map<PassCompany>(createDto);
            var created = await _unitOfWork.PassCompanies.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PassCompanyDto>(created);
        }

        public async Task<PassCompanyDto?> UpdateAsync(UpdatePassCompanyDto updateDto)
        {
            var entity = await _unitOfWork.PassCompanies.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.PassCompanies.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PassCompanyDto>(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var passCompany = await _unitOfWork.PassCompanies.GetByIdAsync(id);
            if (passCompany == null)
                return;

            await _unitOfWork.PassCompanies.DeleteAsync(passCompany.Id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<PassCompanyDto>> GetActiveAsync()
        {
            var passCompanies = await _unitOfWork.PassCompanies.GetActivePassCompaniesAsync();
            return _mapper.Map<IEnumerable<PassCompanyDto>>(passCompanies);
        }
    }
} 