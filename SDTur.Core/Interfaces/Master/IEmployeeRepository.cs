using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.Master
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetActiveEmployeesAsync();
        Task<Employee> GetEmployeeWithBranchAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesByBranchAsync(int branchId);
    }
} 