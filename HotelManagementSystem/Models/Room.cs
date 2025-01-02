namespace HMS.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        // public int HotelId { get; set; }
        // public Hotel? Hotel { get; set; }  // Navigation property for Hotel

        public string RoomType { get; set; }

        public decimal Price { get; set; }

        public string AvailabilityStatus { get; set; }

        public int MaxOccupancy { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();  // Navigation property for Bookings
    }
}
