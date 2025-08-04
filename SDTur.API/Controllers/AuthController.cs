using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.System.Auth;
using SDTur.Application.Services.System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using SDTur.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        private readonly SDTurDbContext _context;

        public AuthController(IAuthService authService, ILogger<AuthController> logger, SDTurDbContext context)
        {
            _authService = authService;
            _logger = logger;
            _context = context;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            _logger.LogInformation("API Test endpoint called");
            return Ok(new { message = "API is working!", timestamp = DateTime.UtcNow });
        }

        [HttpGet("check-users")]
        public IActionResult CheckUsers()
        {
            try
            {
                var users = _context.Users.Where(u => !u.IsDeleted).ToList();
                var userCount = users.Count;
                
                _logger.LogInformation("Found {UserCount} users in database", userCount);
                
                var userList = users.Select(u => new
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    CreatedDate = u.CreatedDate,
                    PasswordHash = u.Password?.Substring(0, Math.Min(20, u.Password?.Length ?? 0)) + "..." // İlk 20 karakteri göster
                }).ToList();

                return Ok(new
                {
                    UserCount = userCount,
                    Users = userList,
                    Message = $"Found {userCount} users in database"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking users");
                return StatusCode(500, new { message = "Error checking users", error = ex.Message });
            }
        }

        [HttpGet("check-passwords")]
        public IActionResult CheckPasswords()
        {
            try
            {
                var users = _context.Users.Where(u => !u.IsDeleted).ToList();
                var userCount = users.Count;
                
                _logger.LogInformation("Checking passwords for {UserCount} users", userCount);
                
                var userList = users.Select(u => new
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    PasswordHash = u.Password,
                    PasswordLength = u.Password?.Length ?? 0,
                    IsBCryptHash = u.Password?.StartsWith("$2") ?? false,
                    CreatedDate = u.CreatedDate,
                    UpdatedDate = u.UpdatedDate
                }).ToList();

                return Ok(new
                {
                    UserCount = userCount,
                    Users = userList,
                    Message = $"Password details for {userCount} users"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking passwords");
                return StatusCode(500, new { message = "Error checking passwords", error = ex.Message });
            }
        }

        [HttpPost("test-password")]
        public async Task<IActionResult> TestPassword([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username && !u.IsDeleted);
                if (user == null)
                {
                    return NotFound(new { message = "User not found" });
                }

                bool passwordValid = false;
                try
                {
                    passwordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password ?? "");
                }
                catch (BCrypt.Net.SaltParseException ex)
                {
                    // Eski plain text şifreler için fallback
                    passwordValid = user.Password == loginDto.Password;
                }

                return Ok(new
                {
                    Username = user.Username,
                    PasswordHash = user.Password?.Substring(0, Math.Min(20, user.Password?.Length ?? 0)) + "...",
                    PasswordValid = passwordValid,
                    IsActive = user.IsActive,
                    Message = passwordValid ? "Password is valid" : "Password is invalid"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error testing password");
                return StatusCode(500, new { message = "Error testing password", error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                _logger.LogInformation("API Login endpoint called with username: {Username}", loginDto.Username);

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("ModelState is invalid for login request");
                    return BadRequest(ModelState);
                }

                var result = await _authService.LoginAsync(loginDto);
                _logger.LogInformation("AuthService result: Success={Success}, Message={Message}", result.Success, result.Message);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred during login for username: {Username}", loginDto.Username);
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            try
            {
                var username = User.Identity?.Name;
                _logger.LogInformation("Logout request for user: {Username}", username);
                
                // JWT token blacklist logic can be implemented here
                return Ok(new { message = "Logout successful" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred during logout");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            try
            {
                _logger.LogInformation("API ChangePassword endpoint called");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("ModelState is invalid for change password request");
                    return BadRequest(ModelState);
                }

                // Extract user ID from JWT token
                var userIdClaim = User.FindFirst("sub") ?? User.FindFirst("nameid");
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId) || userId == 0)
                {
                    _logger.LogWarning("UserId is 0, returning Unauthorized");
                    return Unauthorized(new { message = "Invalid user" });
                }

                _logger.LogDebug("Extracted userId: {UserId}", userId);
                _logger.LogDebug("Calling AuthService.ChangePasswordAsync with userId: {UserId}", userId);

                var result = await _authService.ChangePasswordAsync(userId, changePasswordDto);
                _logger.LogInformation("AuthService.ChangePasswordAsync result: {Result}", result);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred during password change");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("current-user")]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            try
            {
                var username = User.Identity?.Name;
                var userId = User.FindFirst("sub")?.Value ?? User.FindFirst("nameid")?.Value;
                var role = User.FindFirst("role")?.Value;

                _logger.LogInformation("GetCurrentUser called for user: {Username}, Id: {UserId}, Role: {Role}", username, userId, role);

                var userInfo = new
                {
                    Id = userId,
                    Username = username,
                    Role = role,
                    Claims = User.Claims.Select(c => new { c.Type, c.Value })
                };

                return Ok(userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while getting current user");
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
} 