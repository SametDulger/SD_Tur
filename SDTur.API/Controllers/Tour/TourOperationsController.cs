using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Tour.TourOperation;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.API.Controllers.Tour
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourOperationsController : ControllerBase
    {
        private readonly ITourOperationService _tourOperationService;

        public TourOperationsController(ITourOperationService tourOperationService)
        {
            _tourOperationService = tourOperationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourOperationDto>>> GetAll()
        {
            var tourOperations = await _tourOperationService.GetAllAsync();
            return Ok(tourOperations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourOperationDto>> GetById(int id)
        {
            var tourOperation = await _tourOperationService.GetByIdAsync(id);
            if (tourOperation == null)
                return NotFound();

            return Ok(tourOperation);
        }

        [HttpGet("tour-schedule/{tourScheduleId}")]
        public async Task<ActionResult<IEnumerable<TourOperationDto>>> GetByTourSchedule(int tourScheduleId)
        {
            var tourOperations = await _tourOperationService.GetByTourScheduleAsync(tourScheduleId);
            return Ok(tourOperations);
        }

        [HttpGet("operation-type/{operationType}")]
        public async Task<ActionResult<IEnumerable<TourOperationDto>>> GetByOperationType(string operationType)
        {
            var tourOperations = await _tourOperationService.GetByOperationTypeAsync(operationType);
            return Ok(tourOperations);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<TourOperationDto>>> GetByStatus(string status)
        {
            var tourOperations = await _tourOperationService.GetByStatusAsync(status);
            return Ok(tourOperations);
        }

        [HttpPost]
        public async Task<ActionResult<TourOperationDto>> Create(CreateTourOperationDto createDto)
        {
            try
            {
                var tourOperation = await _tourOperationService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = tourOperation.Id }, tourOperation);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTourOperationDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest();

            try
            {
                var tourOperation = await _tourOperationService.UpdateAsync(updateDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tourOperationService.DeleteAsync(id);
            return NoContent();
        }
    }
} 