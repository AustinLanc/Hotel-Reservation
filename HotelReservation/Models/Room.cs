namespace HotelReservation.Models;

public class Room
{
    // Identifier info
    public int Id { get; set; }

    // Hotel info
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }

    // Type info
    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }

    // Room info
    public string RoomNumber { get; set; }
    public int MaxOccupancy { get; set; }
    public decimal BasePricePerNight { get; set; }
    public bool IsActive { get; set; } = true;
}