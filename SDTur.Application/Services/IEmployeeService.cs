using SDTur.Application.DTOs;

namespace SDTur.Application.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<IEnumerable<EmployeeDto>> GetActiveEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByBranchAsync(int branchId);
        Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task<EmployeeDto> UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
        Task DeleteEmployeeAsync(int id);
    }
} 