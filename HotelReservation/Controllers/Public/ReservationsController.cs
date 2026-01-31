namespace HotelReservation.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/reservations")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationsController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    // GET routes
    [HttpGet]
    public async Task<IActionResult> GetReservations()
    {
        var reservations = await _reservationService.GetReservationsAsync();
        return Ok(reservations);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservationById(int id)
    {
        var reservation = await _reservationService.GetByIdAsync(id);

        if (reservation == null)
            return NotFound();

        return Ok(reservation);
    }

    // POST route
    [HttpPost]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto dto)
    {
        var createdReservation = await _reservationService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.Id }, createdReservation);
    }

    // PUT route
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReservation(int id, [FromBody] UpdateReservationDto dto)
    {
        var success = await _reservationService.UpdateAsync(id, dto);

        if (!success)
            return NotFound();

        return NoContent();
    }

    // DELETE route
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(int id)
    {
        var success = await _reservationService.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}