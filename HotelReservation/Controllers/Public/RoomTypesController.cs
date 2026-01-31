namespace HotelReservation.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/room-types")]
public class RoomTypesController : ControllerBase
{
    private readonly IRoomTypeService _roomTypeService;

    public RoomTypesController(IRoomTypeService roomTypeService)
    {
        _roomTypeService = roomTypeService;
    }
    
    // GET routes
    [HttpGet]
    public async Task<IActionResult> GetRoomTypes([FromQuery] int hotelId)
    {
        var roomTypes = await _roomTypeService.GetRoomTypesByHotelAsync(hotelId);
        return Ok(roomTypes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomTypeById(int id)
    {
        var roomType = await _roomTypeService.GetByIdAsync(id);

        if (roomType == null)
            return NotFound();

        return Ok(roomType);
    }
    
    // POST route
    [HttpPost]
    public async Task<IActionResult> CreateRoomType([FromBody] CreateRoomTypeDto dto)
    {
        var createdRoomType = await _roomTypeService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetRoomTypeById), new { id = createdRoomType.Id }, createdRoomType);
    }

    // PUT route
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoomType(int id, [FromBody] UpdateRoomTypeDto dto)
    {
        var success = await _roomTypeService.UpdateAsync(id, dto);

        if (!success)
            return NotFound();

        return NoContent();
    }

    // DELETE route
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoomType(int id)
    {
        var success = await _roomTypeService.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}