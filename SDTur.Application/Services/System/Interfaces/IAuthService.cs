using SDTur.Application.DTOs.System.Auth;
using SDTur.Application.DTOs.System.User;

namespace SDTur.Application.Services.System.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto changePasswordDto);
        Task<string> GenerateTokenAsync(UserDto user);
        Task<string> GenerateRefreshTokenAsync();
        Task<bool> ValidateTokenAsync(string token);
        Task<bool> LogoutAsync(string token);
        Task<UserInfoDto?> GetCurrentUserAsync(int userId);
    }
} 