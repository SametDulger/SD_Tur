using AutoMapper;
using SDTur.Application.DTOs.Master.Employee;
using SDTur.Core.Entities.Master;
using SDTur.Core.Interfaces.Core;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.Application.Services.Master.Implementations
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
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees.Where(e => e.IsActive));
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            return employee != null ? _mapper.Map<EmployeeDto>(employee) : null;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByBranchAsync(int branchId)
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees.Where(e => e.BranchId == branchId));
        }

        public async Task<EmployeeDto?> CreateAsync(CreateEmployeeDto createDto)
        {
            var entity = _mapper.Map<Employee>(createDto);
            var created = await _unitOfWork.Employees.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<EmployeeDto>(created);
        }

        public async Task<EmployeeDto?> UpdateAsync(UpdateEmployeeDto updateDto)
        {
            var entity = await _unitOfWork.Employees.GetByIdAsync(updateDto.Id);
            if (entity == null) return null;
            _mapper.Map(updateDto, entity);
            var updated = await _unitOfWork.Employees.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<EmployeeDto>(updated);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null)
                return;

            await _unitOfWork.Employees.DeleteAsync(employee.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
} 