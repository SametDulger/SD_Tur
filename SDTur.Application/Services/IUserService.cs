using SDTur.Application.DTOs;

namespace SDTur.Application.Services
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