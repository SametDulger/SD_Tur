using SDTur.Core.Entities.System;
using SDTur.Core.Interfaces.Core;

namespace SDTur.Core.Interfaces.System
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserWithDetailsAsync(int id);
        Task<IEnumerable<User>> GetActiveUsersAsync();
        Task<IEnumerable<User>> GetUsersByRoleAsync(int roleId);
    }
} 