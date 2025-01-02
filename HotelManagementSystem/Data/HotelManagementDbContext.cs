using HMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data
{
    public class HotelManagementDbContext : DbContext
    {
        public HotelManagementDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
 
        }
 
        public DbSet<User> Users { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Inventory> Inventories {get; set;}
 
    }
}
