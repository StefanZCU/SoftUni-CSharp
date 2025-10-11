using HouseRentingSystem.Infrastructure.Data.Models;
using HouseRentingSystem.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Data;

public class HouseRentingDbContext : IdentityDbContext
{
    public HouseRentingDbContext(DbContextOptions<HouseRentingDbContext> options)
        : base(options)
    {
    }

    public DbSet<House> Houses { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Agent> Agents { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new AgentConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new HouseConfiguration());
    }
}