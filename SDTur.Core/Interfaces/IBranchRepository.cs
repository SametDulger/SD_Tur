using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface IBranchRepository : IRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetActiveBranchesAsync();
        Task<Branch> GetBranchWithEmployeesAsync(int id);
    }
} 