using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SDTur.Application.DTOs.System.User;
using SDTur.Application.Services.System.Interfaces;
using Microsoft.Extensions.Logging;

namespace SDTur.API.Controllers
{
    /// <summary>
    /// Rol yönetimi için API endpoint'leri
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "System")]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RolesController> _logger;

        public RolesController(IRoleService roleService, ILogger<RolesController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        /// <summary>
        /// Tüm rolleri getirir
        /// </summary>
        /// <returns>Rol listesi</returns>
        /// <response code="200">Başarılı</response>
        /// <response code="401">Yetkilendirme gerekli</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _roleService.GetAllAsync();
                _logger.LogInformation("Retrieved {Count} roles", roles.Count());
                return Ok(roles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving roles");
                return StatusCode(500, new { message = "Roller alınırken hata oluştu", error = ex.Message });
            }
        }

        /// <summary>
        /// Belirtilen ID'ye sahip rolü getirir
        /// </summary>
        /// <param name="id">Rol ID'si</param>
        /// <returns>Rol bilgileri</returns>
        /// <response code="200">Başarılı</response>
        /// <response code="404">Rol bulunamadı</response>
        /// <response code="401">Yetkilendirme gerekli</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetRole(int id)
        {
            try
            {
                var role = await _roleService.GetByIdAsync(id);
                if (role == null)
                {
                    _logger.LogWarning("Role not found with ID: {RoleId}", id);
                    return NotFound(new { message = "Rol bulunamadı" });
                }

                _logger.LogInformation("Retrieved role with ID: {RoleId}", id);
                return Ok(role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving role with ID: {RoleId}", id);
                return StatusCode(500, new { message = "Rol alınırken hata oluştu", error = ex.Message });
            }
        }
    }
} 