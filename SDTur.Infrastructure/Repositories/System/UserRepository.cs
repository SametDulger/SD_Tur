using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.System;
using SDTur.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using SDTur.Infrastructure.Repositories.Core;

namespace SDTur.Infrastructure.Repositories.System
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(SDTurDbContext context, ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            try
            {
                _logger.LogDebug("Getting user by username: {Username}", username);

                if (string.IsNullOrWhiteSpace(username))
                {
                    _logger.LogWarning("GetUserByUsernameAsync called with empty username");
                    return null;
                }

                var user = await _dbSet
                    .Include(u => u.Branch)
                    .Include(u => u.Employee)
                    .FirstOrDefaultAsync(u => u.Username == username && u.IsActive && !u.IsDeleted);

                _logger.LogDebug("Database query completed. User found: {UserFound}", user != null);
                if (user != null)
                {
                    _logger.LogDebug("User details: Id={UserId}, Username={Username}, IsActive={IsActive}", user.Id, user.Username, user.IsActive);
                }
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while getting user by username: {Username}", username);
                return null;
            }
        }

        public new async Task<User?> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogDebug("Getting user by ID: {UserId}", id);

                if (id <= 0)
                {
                    _logger.LogWarning("GetByIdAsync called with invalid ID: {UserId}", id);
                    return null;
                }

                var user = await _dbSet
                    .Include(u => u.Branch)
                    .Include(u => u.Employee)
                    .FirstOrDefaultAsync(u => u.Id == id && u.IsActive && !u.IsDeleted);

                _logger.LogDebug("User found: {UserFound}", user != null);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while getting user by ID: {UserId}", id);
                return null;
            }
        }

        public new async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                _logger.LogDebug("Getting all users");

                var users = await _dbSet
                    .Include(u => u.Branch)
                    .Include(u => u.Employee)
                    .Where(u => u.IsActive && !u.IsDeleted)
                    .ToListAsync();

                _logger.LogDebug("Retrieved {Count} users", users.Count);
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while getting all users");
                return Enumerable.Empty<User>();
            }
        }

        public async Task<IEnumerable<User>> GetActiveUsersAsync()
        {
            return await _dbSet.Where(u => u.IsActive && !u.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            return await _dbSet.Where(u => u.Role == role && u.IsActive && !u.IsDeleted).ToListAsync();
        }

        public async Task<User?> GetUserWithDetailsAsync(int id)
        {
            try
            {
                _logger.LogDebug("Getting user with details by ID: {UserId}", id);

                if (id <= 0)
                {
                    _logger.LogWarning("GetUserWithDetailsAsync called with invalid ID: {UserId}", id);
                    return null;
                }

                var user = await _dbSet
                    .Include(u => u.Branch)
                    .Include(u => u.Employee)
                    .FirstOrDefaultAsync(u => u.Id == id);

                _logger.LogDebug("User with details found: {UserFound}", user != null);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while getting user with details by ID: {UserId}", id);
                return null;
            }
        }

        public new async Task AddAsync(User user)
        {
            try
            {
                _logger.LogInformation("Adding new user: {Username}", user.Username);

                if (user == null)
                {
                    _logger.LogWarning("AddAsync called with null user");
                    return;
                }

                await _dbSet.AddAsync(user);
                _logger.LogInformation("User added successfully: {Username}", user.Username);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while adding user: {Username}", user?.Username);
                throw;
            }
        }

        public new Task UpdateAsync(User user)
        {
            try
            {
                _logger.LogInformation("Updating user: {Username}, Id: {UserId}", user.Username, user.Id);

                if (user == null)
                {
                    _logger.LogWarning("UpdateAsync called with null user");
                    return Task.CompletedTask;
                }

                _dbSet.Update(user);
                _logger.LogInformation("User updated successfully: {Username}", user.Username);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while updating user: {Username}, Id: {UserId}", user?.Username, user?.Id);
                throw;
            }
        }

        public new async Task DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting user with ID: {UserId}", id);

                if (id <= 0)
                {
                    _logger.LogWarning("DeleteAsync called with invalid ID: {UserId}", id);
                    return;
                }

                var user = await _dbSet.FindAsync(id);
                if (user != null)
                {
                    _dbSet.Remove(user);
                    _logger.LogInformation("User deleted successfully: {Username}, Id: {UserId}", user.Username, user.Id);
                }
                else
                {
                    _logger.LogWarning("User not found for deletion: {UserId}", id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while deleting user: {UserId}", id);
                throw;
            }
        }
    }
} 