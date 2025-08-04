using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Tour.TourType;
using SDTur.Application.Services.Tour.Interfaces;

namespace SDTur.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourTypesController : ControllerBase
    {
        private readonly ITourTypeService _tourTypeService;

        public TourTypesController(ITourTypeService tourTypeService)
        {
            _tourTypeService = tourTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourTypeDto>>> GetAll()
        {
            var tourTypes = await _tourTypeService.GetAllAsync();
            return Ok(tourTypes);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<TourTypeDto>>> GetActive()
        {
            var tourTypes = await _tourTypeService.GetActiveAsync();
            return Ok(tourTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourTypeDto>> GetById(int id)
        {
            var tourType = await _tourTypeService.GetByIdAsync(id);
            if (tourType == null)
                return NotFound();

            return Ok(tourType);
        }
    }
} 