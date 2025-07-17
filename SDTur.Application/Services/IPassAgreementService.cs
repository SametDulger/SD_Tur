using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface IPassAgreementService
    {
        Task<IEnumerable<PassAgreementDto>> GetAllAsync();
        Task<PassAgreementDto> GetByIdAsync(int id);
        Task<PassAgreementDto> CreateAsync(CreatePassAgreementDto createDto);
        Task<PassAgreementDto> UpdateAsync(UpdatePassAgreementDto updateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<PassAgreementDto>> GetByPassCompanyAsync(int passCompanyId);
        Task<IEnumerable<PassAgreementDto>> GetByTourAsync(int tourId);
    }
} 