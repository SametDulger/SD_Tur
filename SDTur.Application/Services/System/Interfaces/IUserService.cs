using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.System.User;

namespace SDTur.Application.Services.System.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> GetByUsernameAsync(string username);
        Task<UserDto?> CreateAsync(CreateUserDto createDto);
        Task<bool> UpdateAsync(UserDto userDto);
        Task<bool> DeleteAsync(int id);
    }
} 