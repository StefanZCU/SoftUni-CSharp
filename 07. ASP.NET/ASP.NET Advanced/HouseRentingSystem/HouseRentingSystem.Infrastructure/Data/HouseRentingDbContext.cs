using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Data;

public class HouseRentingDbContext : IdentityDbContext
{
    public HouseRentingDbContext(DbContextOptions<HouseRentingDbContext> options)
        : base(options)
    {
    }

    public DbSet<Agent> Agents { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<House> Houses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<House>()
            .HasOne(h => h.Category)
            .WithMany(c => c.Houses)
            .HasForeignKey(h => h.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Entity<House>()
            .HasOne(h => h.Agent)
            .WithMany()
            .HasForeignKey(h => h.AgentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        base.OnModelCreating(builder);
    }
}