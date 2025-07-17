using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Core.Entities;

namespace SDTur.Core.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetActiveEmployeesAsync();
        Task<Employee> GetEmployeeWithBranchAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesByBranchAsync(int branchId);
    }
} 