namespace HotelReservation.Models;

public class Hotel
{
    // Identifier info
    public int Id { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    
    // Location info
    public String Address { get; set; }
    public String City { get; set; }
    public String State { get; set; }
    public String ZipCode { get; set; }
    
    // Contact info
    public String Phone { get; set; }
    public String Email { get; set; }
}