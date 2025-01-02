// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using HMS.Models;
// using HMS.Data;

// namespace HMS.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class HotelController : ControllerBase
//     {
//         private readonly HotelManagementDbContext _context;

//         public HotelController(HotelManagementDbContext context)
//         {
//             _context = context;
//         }

//         // GET: api/Hotel
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
//         {
//             return await _context.Hotels.ToListAsync();
//         }

//         // GET: api/Hotel/{id}
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Hotel>> GetHotel(int id)
//         {
//             var hotel = await _context.Hotels.FindAsync(id);

//             if (hotel == null)
//             {
//                 return NotFound();
//             }

//             return hotel;
//         }

//         // POST: api/Hotel
//         [HttpPost]
//         public async Task<ActionResult<Hotel>> AddHotel(Hotel hotel)
//         {
//             _context.Hotels.Add(hotel);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetHotel), new { id = hotel.HotelId }, hotel);
//         }

//         // GET: api/Hotel/{hotelId}/Rooms
//         [HttpGet("{hotelId}/Rooms")]
//         public async Task<ActionResult<IEnumerable<Room>>> GetRoomsByHotel(int hotelId)
//         {
//             var rooms = await _context.Rooms.Where(r => r.HotelId == hotelId).ToListAsync();

//             if (!rooms.Any())
//             {
//                 return NotFound("No rooms found for this hotel.");
//             }

//             return rooms;
//         }

//         // POST: api/Hotel/{hotelId}/Rooms
//         [HttpPost("{hotelId}/Rooms")]
//         public async Task<ActionResult<Room>> AddRoom(int hotelId, Room room)
//         {
//             var hotel = await _context.Hotels.FindAsync(hotelId);
//             if (hotel == null)
//             {
//                 return NotFound("Hotel not found.");
//             }

//             room.HotelId = hotelId;
//             _context.Rooms.Add(room);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetRoomsByHotel), new { hotelId = room.HotelId }, room);
//         }

//         // POST: api/Hotel/MakePayment
//         [HttpPost("MakePayment")]
//         public async Task<ActionResult<Payment>> MakePayment(int roomId)
//         {
//             var room = await _context.Rooms.Include(r => r.Hotel).FirstOrDefaultAsync(r => r.RoomId == roomId);
//             if (room == null)
//             {
//                 return NotFound("Room not found.");
//             }

//             var payment = new Payment
//             {
//                 // BookingId = room.BookingId,
//                 Amount = room.Price,
//                 PaymentDate = DateTime.Now,
//                 PaymentStatus = "Pending"
//             };

//             _context.Payments.Add(payment);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction(nameof(MakePayment), new { id = payment.PaymentId }, payment);
//         }

//         private bool HotelExists(int id)
//         {
//             return _context.Hotels.Any(e => e.HotelId == id);
//         }
//     }
// }
