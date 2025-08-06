using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.System;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.System
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<Permission?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Name == name && p.IsActive && !p.IsDeleted);
        }

        public async Task<IEnumerable<Permission>> GetByResourceAsync(string resource)
        {
            return await _dbSet.Where(p => p.Resource == resource && p.IsActive && !p.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Permission>> GetActivePermissionsAsync()
        {
            return await _dbSet.Where(p => p.IsActive && !p.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Permission>> GetPermissionsByRoleAsync(int roleId)
        {
            var role = await _context.Roles.Include(r => r.Permissions).FirstOrDefaultAsync(r => r.Id == roleId);
            return role?.Permissions ?? new List<Permission>();
        }
    }
} 