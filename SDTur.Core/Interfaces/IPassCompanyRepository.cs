using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface IPassCompanyRepository : IRepository<PassCompany>
    {
        Task<IEnumerable<PassCompany>> GetActivePassCompaniesAsync();
        Task<PassCompany> GetPassCompanyWithAgreementsAsync(int id);
    }
} 