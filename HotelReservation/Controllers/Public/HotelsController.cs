namespace HotelReservation.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/hotels")]
public class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelsController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    // GET routes
    [HttpGet]
    public async Task<IActionResult> GetHotels()
    {
        var hotels = await _hotelService.GetHotelsAsync();
        return Ok(hotels);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHotelById(int id)
    {
        var hotel = await _hotelService.GetByIdAsync(id);

        if (hotel == null)
            return NotFound();

        return Ok(hotel);
    }

    // POST route
    [HttpPost]
    public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDto dto)
    {
        var createdHotel = await _hotelService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetHotelById), new { id = createdHotel.Id }, createdHotel);
    }

    // PUT route
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelDto dto)
    {
        var success = await _hotelService.UpdateAsync(id, dto);

        if (!success)
            return NotFound();

        return NoContent();
    }

    // DELETE route
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var success = await _hotelService.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}