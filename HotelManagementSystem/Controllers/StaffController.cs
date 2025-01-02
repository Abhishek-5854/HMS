using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly DbContext _context;

        public StaffController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Staff
        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            var staff = await _context.Set<Staff>().ToListAsync();
            return Ok(staff);
        }

        // GET: api/Staff/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            var staff = await _context.Set<Staff>().FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

        // POST: api/Staff
        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody] Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Set<Staff>().AddAsync(staff);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStaffById), new { id = staff.StaffId }, staff);
        }

        // PUT: api/Staff/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaff(int id, [FromBody] Staff updatedStaff)
        {
            if (id != updatedStaff.StaffId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingStaff = await _context.Set<Staff>().FindAsync(id);
            if (existingStaff == null)
            {
                return NotFound();
            }

            existingStaff.FirstName = updatedStaff.FirstName;
            existingStaff.LastName = updatedStaff.LastName;
            existingStaff.Email = updatedStaff.Email;
            existingStaff.PhoneNumber = updatedStaff.PhoneNumber;
            existingStaff.Address = updatedStaff.Address;
            existingStaff.Gender = updatedStaff.Gender;
            existingStaff.Salary = updatedStaff.Salary;
            existingStaff.Role = updatedStaff.Role;

            _context.Set<Staff>().Update(existingStaff);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Staff/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _context.Set<Staff>().FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Set<Staff>().Remove(staff);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
