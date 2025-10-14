using GameZoneUpdated.Infrastructure.Data.Models;
using GameZoneUpdated.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameZoneUpdated.Infrastructure.Data;

public class GameZoneDbContext : IdentityDbContext
{
    public GameZoneDbContext(DbContextOptions<GameZoneDbContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<GamerGame> GamersGames { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<GamerGame>()
            .HasKey(g => new { g.GamerId, g.GameId });
        
        builder.Entity<GamerGame>()
            .HasOne(g => g.Gamer)
            .WithMany()
            .HasForeignKey(g => g.GamerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ApplyConfiguration(new GenreConfiguration());
    }
}