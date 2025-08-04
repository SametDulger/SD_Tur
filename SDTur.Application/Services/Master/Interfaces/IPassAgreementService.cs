using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Master.PassAgreement;

namespace SDTur.Application.Services.Master.Interfaces
{
    public interface IPassAgreementService
    {
        Task<IEnumerable<PassAgreementDto>> GetAllAsync();
        Task<PassAgreementDto?> GetByIdAsync(int id);
        Task<PassAgreementDto?> CreateAsync(CreatePassAgreementDto createDto);
        Task<PassAgreementDto?> UpdateAsync(UpdatePassAgreementDto updateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<PassAgreementDto>> GetByPassCompanyAsync(int passCompanyId);
        Task<IEnumerable<PassAgreementDto>> GetByTourAsync(int tourId);
    }
} 