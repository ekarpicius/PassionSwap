using Microsoft.EntityFrameworkCore;
using PassionSwap.Models;

namespace PassionSwap.Data
{
    public class PassionSwap_DbContext : DbContext
    {
        public PassionSwap_DbContext(DbContextOptions<PassionSwap_DbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Listing> Listings { get; set; }
    }
}
