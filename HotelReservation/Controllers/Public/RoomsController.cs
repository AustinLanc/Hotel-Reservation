namespace HotelReservation.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/rooms")]
public class RoomsController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomsController(IRoomService roomService)
    {
        _roomService = roomService;
    }
    
    // GET routes
    [HttpGet]
    public async Task<IActionResult> GetRooms([FromQuery] int hotelId)
    {
        var rooms = await _roomService.GetRoomsByHotelAsync(hotelId);
        return Ok(rooms);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomById(int id)
    {
        var room = await _roomService.GetByIdAsync(id);

        if (room == null)
            return NotFound();

        return Ok(room);
    }

    // POST route
    [HttpPost]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDto dto)
    {
        var createdRoom = await _roomService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, createdRoom);
    }

    // PUT route
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(int id, [FromBody] UpdateRoomDto dto)
    {
        var success = await _roomService.UpdateAsync(id, dto);

        if (!success)
            return NotFound();

        return NoContent();
    }

    // DELETE route
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var success = await _roomService.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}
