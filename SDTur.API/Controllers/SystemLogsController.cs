using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.System.SystemLog;
using SDTur.Application.Services.System.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemLogsController : ControllerBase
    {
        private readonly ISystemLogService _systemLogService;

        public SystemLogsController(ISystemLogService systemLogService)
        {
            _systemLogService = systemLogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemLogDto>>> GetAll()
        {
            var systemLogs = await _systemLogService.GetAllAsync();
            return Ok(systemLogs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SystemLogDto>> GetById(int id)
        {
            var systemLog = await _systemLogService.GetByIdAsync(id);
            if (systemLog == null)
                return NotFound();
            return Ok(systemLog);
        }

        [HttpGet("date-range")]
        public async Task<ActionResult<IEnumerable<SystemLogDto>>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var systemLogs = await _systemLogService.GetByDateRangeAsync(startDate, endDate);
            return Ok(systemLogs);
        }

        [HttpGet("log-level/{logLevel}")]
        public async Task<ActionResult<IEnumerable<SystemLogDto>>> GetByLogLevel(string logLevel)
        {
            var systemLogs = await _systemLogService.GetByLogLevelAsync(logLevel);
            return Ok(systemLogs);
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<SystemLogDto>>> GetByCategory(string category)
        {
            var systemLogs = await _systemLogService.GetByCategoryAsync(category);
            return Ok(systemLogs);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<SystemLogDto>>> GetByUser(int userId)
        {
            var systemLogs = await _systemLogService.GetByUserAsync(userId);
            return Ok(systemLogs);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<SystemLogDto>>> GetByEmployee(int employeeId)
        {
            var systemLogs = await _systemLogService.GetByEmployeeAsync(employeeId);
            return Ok(systemLogs);
        }

        [HttpGet("action/{action}")]
        public async Task<ActionResult<IEnumerable<SystemLogDto>>> GetByAction(string action)
        {
            var systemLogs = await _systemLogService.GetByActionAsync(action);
            return Ok(systemLogs);
        }

        [HttpPost]
        public async Task<ActionResult<SystemLogDto>> Create(CreateSystemLogDto createDto)
        {
            var systemLog = await _systemLogService.CreateAsync(createDto);
            if (systemLog == null)
                return BadRequest("Failed to create system log");
            return CreatedAtAction(nameof(GetById), new { id = systemLog.Id }, systemLog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSystemLogDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();
            var systemLog = await _systemLogService.UpdateAsync(updateDto);
            if (systemLog == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _systemLogService.DeleteAsync(id);
            return NoContent();
        }
    }
} 
