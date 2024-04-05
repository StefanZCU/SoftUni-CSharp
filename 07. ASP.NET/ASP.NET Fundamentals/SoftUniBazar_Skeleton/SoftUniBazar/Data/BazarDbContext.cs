using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data.Models;

namespace SoftUniBazar.Data
{
    public class BazarDbContext : IdentityDbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<AdBuyer>()
                .HasKey(eb => new { eb.AdId, eb.BuyerId });

            modelBuilder
                .Entity<AdBuyer>()
                .HasOne(a => a.Buyer)
                .WithMany()
                .HasForeignKey(a => a.BuyerId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder
                .Entity<AdBuyer>()
                .HasOne(a => a.Ad)
                .WithMany()
                .HasForeignKey(a => a.AdId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cars"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Technology"
                });
            
             base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<AdBuyer> AdBuyers { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}