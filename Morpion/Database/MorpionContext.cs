using Microsoft.EntityFrameworkCore;

namespace Morpion.Database
{
    public class MorpionContext : DbContext
    {
        public DbSet<GameRecord> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Username=morpion;Password=morpion123;Database=morpion");
        }

    }
}