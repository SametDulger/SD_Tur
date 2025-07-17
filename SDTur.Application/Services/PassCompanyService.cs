using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
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

        public async Task<PassCompanyDto> GetByIdAsync(int id)
        {
            var passCompany = await _unitOfWork.PassCompanies.GetByIdAsync(id);
            return _mapper.Map<PassCompanyDto>(passCompany);
        }

        public async Task<PassCompanyDto> CreateAsync(CreatePassCompanyDto createDto)
        {
            var passCompany = _mapper.Map<PassCompany>(createDto);
            passCompany.IsActive = true;
            
            await _unitOfWork.PassCompanies.AddAsync(passCompany);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<PassCompanyDto>(passCompany);
        }

        public async Task<PassCompanyDto> UpdateAsync(UpdatePassCompanyDto updateDto)
        {
            var passCompany = await _unitOfWork.PassCompanies.GetByIdAsync(updateDto.Id);
            if (passCompany == null)
                throw new ArgumentException("Pas şirketi bulunamadı");

            _mapper.Map(updateDto, passCompany);
            
            await _unitOfWork.PassCompanies.UpdateAsync(passCompany);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<PassCompanyDto>(passCompany);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.PassCompanies.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<PassCompanyDto>> GetActiveAsync()
        {
            var passCompanies = await _unitOfWork.PassCompanies.GetActivePassCompaniesAsync();
            return _mapper.Map<IEnumerable<PassCompanyDto>>(passCompanies);
        }
    }
} 