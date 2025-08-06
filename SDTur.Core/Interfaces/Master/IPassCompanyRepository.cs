using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Master
{
    public interface IPassCompanyRepository : IRepository<PassCompany>
    {
        Task<IEnumerable<PassCompany>> GetActivePassCompaniesAsync();
        Task<PassCompany?> GetPassCompanyWithAgreementsAsync(int id);
    }
} 