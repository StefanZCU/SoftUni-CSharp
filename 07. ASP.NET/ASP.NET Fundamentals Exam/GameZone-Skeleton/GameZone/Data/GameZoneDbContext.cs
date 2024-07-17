using GameZone.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class GameZoneDbContext : IdentityDbContext
    {
        public GameZoneDbContext(DbContextOptions<GameZoneDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<GamerGame>()
                .HasKey(gg => new { gg.GameId, gg.GamerId });

            builder.Entity<GamerGame>()
                .HasOne(gg => gg.Gamer)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);

            builder
                .Entity<Genre>()
                .HasData(
                    new Genre { Id = 1, Name = "Action" },
                    new Genre { Id = 2, Name = "Adventure" },
                    new Genre { Id = 3, Name = "Fighting" },
                    new Genre { Id = 4, Name = "Sports" },
                    new Genre { Id = 5, Name = "Racing" },
                    new Genre { Id = 6, Name = "Strategy" });
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<GamerGame> GamersGames { get; set; }
    }
}