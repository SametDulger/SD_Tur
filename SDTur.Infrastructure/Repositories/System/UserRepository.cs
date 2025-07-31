using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.System;
using SDTur.Infrastructure.Data;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.System
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SDTurDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbSet
                .Include(u => u.Employee)
                .Include(u => u.Branch)
                .FirstOrDefaultAsync(u => u.Username == username && u.IsActive);
        }

        public async Task<User> GetUserWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(u => u.Employee)
                .Include(u => u.Branch)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return await _dbSet
                .Include(u => u.Employee)
                .Include(u => u.Branch)
                .Where(u => u.IsActive)
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            return await _dbSet
                .Include(u => u.Employee)
                .Include(u => u.Branch)
                .Where(u => u.Role == role && u.IsActive)
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToListAsync();
        }
    }
} 