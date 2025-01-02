// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using HMS.Models;
// using HMS.Data;

// namespace HMS.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class RoomsController : ControllerBase
//     {
//         private readonly HotelManagementDbContext _context;

//         public RoomsController(HotelManagementDbContext context)
//         {
//             _context = context;
//         }

//         // GET: api/Rooms
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
//         {
//             // return await _context.Rooms.Include(r => r.Hotel).ToListAsync();
//         }

//         // GET: api/Rooms/{id}
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Room>> GetRoom(int id)
//         {
//             var room = await _context.Rooms.Include(r => r.Hotel).FirstOrDefaultAsync(r => r.RoomId == id);

//             if (room == null)
//             {
//                 return NotFound();
//             }

//             return room;
//         }

//         // POST: api/Rooms
//         [HttpPost]
//         public async Task<ActionResult<Room>> AddRoom(Room room)
//         {
//             // Detach Hotel and Booking navigation properties to prevent EF from validating them
//             room.Hotel = null;
//             room.Bookings = null;

//             _context.Rooms.Add(room);

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateException ex)
//             {
//                 // Log the error for debugging purposes
//                 Console.WriteLine(ex.Message);

//                 return BadRequest("Unable to add room. Please check the data.");
//             }

//             return CreatedAtAction(nameof(GetRoom), new { id = room.RoomId }, room);
//         }


//         // PUT: api/Rooms/{id}
//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateRoom(int id, Room room)
//         {
//             if (id != room.RoomId)
//             {
//                 return BadRequest("Room ID mismatch.");
//             }

//             _context.Entry(room).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!RoomExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // DELETE: api/Rooms/{id}
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteRoom(int id)
//         {
//             var room = await _context.Rooms.FindAsync(id);
//             if (room == null)
//             {
//                 return NotFound();
//             }

//             _context.Rooms.Remove(room);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         // GET: api/Rooms/Search?roomType={roomType}&hotelId={hotelId}&availabilityStatus={availabilityStatus}
//         [HttpGet("Search")]
//         public async Task<ActionResult<IEnumerable<Room>>> SearchRooms(string roomType, int? hotelId, string availabilityStatus)
//         {
//             var query = _context.Rooms.Include(r => r.Hotel).AsQueryable();

//             if (!string.IsNullOrEmpty(roomType))
//             {
//                 query = query.Where(r => r.RoomType.Contains(roomType));
//             }

//             if (hotelId.HasValue)
//             {
//                 query = query.Where(r => r.HotelId == hotelId.Value);
//             }

//             if (!string.IsNullOrEmpty(availabilityStatus))
//             {
//                 query = query.Where(r => r.AvailabilityStatus.Contains(availabilityStatus));
//             }

//             return await query.ToListAsync();
//         }

//         private bool RoomExists(int id)
//         {
//             return _context.Rooms.Any(e => e.RoomId == id);
//         }
//     }
// }
