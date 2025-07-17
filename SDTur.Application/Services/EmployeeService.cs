using AutoMapper;
using SDTur.Application.DTOs;
using SDTur.Core.Entities;
using SDTur.Core.Interfaces;

namespace SDTur.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<IEnumerable<EmployeeDto>> GetActiveEmployeesAsync()
        {
            var employees = await _unitOfWork.Employees.GetActiveEmployeesAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetEmployeeWithBranchAsync(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByBranchAsync(int branchId)
        {
            var employees = await _unitOfWork.Employees.GetEmployeesByBranchAsync(branchId);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            var employee = _mapper.Map<Employee>(createEmployeeDto);
            employee.IsActive = true;
            
            var createdEmployee = await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<EmployeeDto>(createdEmployee);
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            var existingEmployee = await _unitOfWork.Employees.GetByIdAsync(updateEmployeeDto.Id);
            if (existingEmployee == null)
                return null;

            _mapper.Map(updateEmployeeDto, existingEmployee);
            
            var updatedEmployee = await _unitOfWork.Employees.UpdateAsync(existingEmployee);
            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<EmployeeDto>(updatedEmployee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _unitOfWork.Employees.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 