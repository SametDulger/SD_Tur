using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.System
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<Permission?> GetByNameAsync(string name);
        Task<IEnumerable<Permission>> GetByResourceAsync(string resource);
        Task<IEnumerable<Permission>> GetActivePermissionsAsync();
        Task<IEnumerable<Permission>> GetPermissionsByRoleAsync(int roleId);
    }
} 