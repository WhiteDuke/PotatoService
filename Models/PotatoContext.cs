using Microsoft.EntityFrameworkCore;

namespace PotatoPlace.Models
{
    public class PotatoContext : DbContext
    {
        public DbSet<Type> Types { get; set; }

        public DbSet<Potato> Potatoes { get; set; }

        public PotatoContext(DbContextOptions<PotatoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}