using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.System;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.System
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<Role?> GetByNameAsync(string name)
        {
            return await _dbSet.Include(r => r.Permissions).FirstOrDefaultAsync(r => r.Name == name && r.IsActive && !r.IsDeleted);
        }

        public async Task<IEnumerable<Role>> GetActiveRolesAsync()
        {
            return await _dbSet.Include(r => r.Permissions).Where(r => r.IsActive && !r.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Permission>> GetRolePermissionsAsync(int roleId)
        {
            var role = await _dbSet.Include(r => r.Permissions).FirstOrDefaultAsync(r => r.Id == roleId);
            return role?.Permissions ?? new List<Permission>();
        }

        public async Task AssignPermissionToRoleAsync(int roleId, int permissionId)
        {
            var role = await _dbSet.Include(r => r.Permissions).FirstOrDefaultAsync(r => r.Id == roleId);
            var permission = await _context.Permissions.FirstOrDefaultAsync(p => p.Id == permissionId);
            
            if (role != null && permission != null && !role.Permissions.Any(p => p.Id == permissionId))
            {
                role.Permissions.Add(permission);
                _dbSet.Update(role);
            }
        }

        public async Task RemovePermissionFromRoleAsync(int roleId, int permissionId)
        {
            var role = await _dbSet.Include(r => r.Permissions).FirstOrDefaultAsync(r => r.Id == roleId);
            var permission = role?.Permissions.FirstOrDefault(p => p.Id == permissionId);
            
            if (role != null && permission != null)
            {
                role.Permissions.Remove(permission);
                _dbSet.Update(role);
            }
        }
    }
} 