using Microsoft.EntityFrameworkCore;

namespace TTracker.Models
{
    public class TTrackerDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public TTrackerDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
