using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure
{
    public class JourneyDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public DbSet<Activity> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\thiag\\OneDrive\\Documentos\\3. Rocketseat\\NLW - Thiago\\1. Trilha C#\\JourneyDatabase.db");
        }
    }
}
