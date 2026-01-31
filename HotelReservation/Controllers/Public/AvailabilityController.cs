namespace HotelReservation.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/availability")]
public class AvailabilityController : ControllerBase
{
    private readonly IAvailabilityService _availabilityService;

    public AvailabilityController(IAvailabilityService availabilityService)
    {
        _availabilityService = availabilityService;
    }

    // GET routes
    [HttpGet]
    public async Task<IActionResult> GetAvailabilities()
    {
        var availabilities = await _availabilityService.GetAvailabilitiesAsync();
        return Ok(availabilities);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAvailabilityById(int id)
    {
        var availability = await _availabilityService.GetByIdAsync(id);

        if (availability == null)
            return NotFound();

        return Ok(availability);
    }

    // POST route
    [HttpPost]
    public async Task<IActionResult> CreateAvailability([FromBody] CreateAvailabilityDto dto)
    {
        var createdAvailability = await _availabilityService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAvailabilityById), new { id = createdAvailability.Id }, createdAvailability);
    }

    // PUT route
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAvailability(int id, [FromBody] UpdateAvailabilityDto dto)
    {
        var success = await _availabilityService.UpdateAsync(id, dto);

        if (!success)
            return NotFound();

        return NoContent();
    }

    // DELETE route
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAvailability(int id)
    {
        var success = await _availabilityService.DeleteAsync(id);

        if (!success)
            return NotFound();

        return NoContent();
    }
}