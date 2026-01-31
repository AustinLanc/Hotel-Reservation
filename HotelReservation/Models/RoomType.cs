namespace HotelReservation.Models;

public class RoomType
{
    // Identifier info
    public int Id { get; set; }

    // Type info
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxOccupancy { get; set; }
    public decimal BasePricePerNight { get; set; }

    // Collection info
    public ICollection<Room> Rooms { get; set; }
}
