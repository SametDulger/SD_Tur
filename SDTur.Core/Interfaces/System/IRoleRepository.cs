using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.System
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role?> GetByNameAsync(string name);
        Task<IEnumerable<Role>> GetActiveRolesAsync();
        Task<IEnumerable<Permission>> GetRolePermissionsAsync(int roleId);
        Task AssignPermissionToRoleAsync(int roleId, int permissionId);
        Task RemovePermissionFromRoleAsync(int roleId, int permissionId);
    }
} 