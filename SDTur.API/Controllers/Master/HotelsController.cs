using Microsoft.AspNetCore.Mvc;
using SDTur.Application.DTOs.Master.Hotel;
using SDTur.Application.Services.Master.Interfaces;

namespace SDTur.API.Controllers.Master
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            var hotels = await _hotelService.GetAllHotelsAsync();
            return Ok(hotels);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetActiveHotels()
        {
            var hotels = await _hotelService.GetActiveHotelsAsync();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpGet("region/{regionId}")]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotelsByRegion(int regionId)
        {
            var hotels = await _hotelService.GetHotelsByRegionAsync(regionId);
            return Ok(hotels);
        }

        [HttpPost]
        public async Task<ActionResult<HotelDto>> CreateHotel(CreateHotelDto createHotelDto)
        {
            var hotel = await _hotelService.CreateHotelAsync(createHotelDto);
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, UpdateHotelDto updateHotelDto)
        {
            if (id != updateHotelDto.Id)
                return BadRequest();

            var hotel = await _hotelService.UpdateHotelAsync(updateHotelDto);
            if (hotel == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotelService.DeleteHotelAsync(id);
            return NoContent();
        }
    }
} 