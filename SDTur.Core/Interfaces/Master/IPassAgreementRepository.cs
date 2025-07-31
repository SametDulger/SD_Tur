using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Master
{
    public interface IPassAgreementRepository : IRepository<PassAgreement>
    {
        Task<IEnumerable<PassAgreement>> GetAgreementsByPassCompanyAsync(int passCompanyId);
        Task<IEnumerable<PassAgreement>> GetAgreementsByTourAsync(int tourId);
        Task<PassAgreement> GetAgreementByCompanyAndTourAsync(int passCompanyId, int tourId);
    }
} 