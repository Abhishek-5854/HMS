using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int RoomId { get; set; }  // Foreign key for Room

        [ForeignKey("RoomId")]
        public Room? Room { get; set; }  // Navigation property for Room
    }
}
