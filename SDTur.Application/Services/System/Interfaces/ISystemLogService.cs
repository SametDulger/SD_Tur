using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.System.SystemLog;

namespace SDTur.Application.Services.System.Interfaces
{
    public interface ISystemLogService
    {
        Task<IEnumerable<SystemLogDto>> GetAllAsync();
        Task<SystemLogDto?> GetByIdAsync(int id);
        Task<IEnumerable<SystemLogDto>> GetByUserAsync(int userId);
        Task<IEnumerable<SystemLogDto>> GetByEmployeeAsync(int employeeId);
        Task<IEnumerable<SystemLogDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<SystemLogDto>> GetByLogLevelAsync(string logLevel);
        Task<IEnumerable<SystemLogDto>> GetByCategoryAsync(string category);
        Task<IEnumerable<SystemLogDto>> GetByActionAsync(string action);
        Task<SystemLogDto?> CreateAsync(CreateSystemLogDto createDto);
        Task<SystemLogDto?> UpdateAsync(UpdateSystemLogDto updateDto);
        Task DeleteAsync(int id);
    }
} 