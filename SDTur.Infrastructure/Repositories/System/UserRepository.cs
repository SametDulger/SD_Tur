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
            Console.WriteLine($"UserRepository.GetUserByUsernameAsync called with username: {username}");
            try
            {
                var user = await _dbSet
                    .Include(u => u.Employee)
                    .Include(u => u.Branch)
                    .FirstOrDefaultAsync(u => u.Username == username && u.IsActive);
                
                Console.WriteLine($"Database query completed. User found: {user != null}");
                if (user != null)
                {
                    Console.WriteLine($"User details: Id={user.Id}, Username={user.Username}, Password={user.Password}, IsActive={user.IsActive}");
                }
                
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in UserRepository.GetUserByUsernameAsync: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
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