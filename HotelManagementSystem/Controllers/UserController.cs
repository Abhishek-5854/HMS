// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using HMS.Models;
// using HMS.Data;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace HMS.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class UsersController : ControllerBase
//     {
//         private readonly HotelManagementDbContext _context;

//         public UsersController(HotelManagementDbContext context)
//         {
//             _context = context;
//         }

//         // GET: api/Users
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<User>>> GetUsers()
//         {
//             return await _context.Users.Include(u => u.Role).ToListAsync();
//         }

//         // GET: api/Users/{id}
//         [HttpGet("{id}")]
//         public async Task<ActionResult<User>> GetUser(int id)
//         {
//             var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserId == id);

//             if (user == null)
//             {
//                 return NotFound();
//             }

//             return user;
//         }

//         // POST: api/Users
//         [HttpPost]
//         public async Task<ActionResult<User>> AddUser(User user)
//         {
//             _context.Users.Add(user);

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateException ex)
//             {
//                 Console.WriteLine(ex.Message);
//                 return BadRequest("Unable to add user. Please check the data.");
//             }

//             return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
//         }

//         // PUT: api/Users/{id}
//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateUser(int id, User user)
//         {
//             if (id != user.UserId)
//             {
//                 return BadRequest("User ID mismatch.");
//             }

//             _context.Entry(user).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!UserExists(id))
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

//         // DELETE: api/Users/{id}
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteUser(int id)
//         {
//             var user = await _context.Users.FindAsync(id);
//             if (user == null)
//             {
//                 return NotFound();
//             }

//             _context.Users.Remove(user);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         private bool UserExists(int id)
//         {
//             return _context.Users.Any(e => e.UserId == id);
//         }
//     }
// }
