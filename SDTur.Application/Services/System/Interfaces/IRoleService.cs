using SDTur.Application.DTOs.System.User;

namespace SDTur.Application.Services.System.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto?> GetByIdAsync(int id);
        Task<RoleDto?> CreateAsync(CreateRoleDto createDto);
        Task<bool> UpdateAsync(RoleDto roleDto);
        Task<bool> DeleteAsync(int id);
    }
} 