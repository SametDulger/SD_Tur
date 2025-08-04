using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.Master.Employee;

namespace SDTur.Application.Services.Master.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto?> CreateAsync(CreateEmployeeDto createDto);
        Task<EmployeeDto?> UpdateAsync(UpdateEmployeeDto updateDto);
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<IEnumerable<EmployeeDto>> GetActiveEmployeesAsync();
        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByBranchAsync(int branchId);
        Task DeleteEmployeeAsync(int id);
    }
} 