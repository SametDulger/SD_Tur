using System.Collections.Generic;
using System.Threading.Tasks;
using SDTur.Application.DTOs.System.User;

namespace SDTur.Application.Services.System.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<IEnumerable<UserDto>> GetActiveAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> GetByUsernameAsync(string username);
        Task<UserDto> CreateAsync(CreateUserDto createDto);
        Task<UserDto> UpdateAsync(UpdateUserDto updateDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<UserDto>> GetByRoleAsync(string role);
    }
} 