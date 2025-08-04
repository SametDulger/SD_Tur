using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Master
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetActiveBranchesAsync();
        Task<Branch?> GetBranchWithEmployeesAsync(int id);
    }
} 