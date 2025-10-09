using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data.Models;

namespace SeminarHub.Data
{
    public class SeminarHubDbContext : IdentityDbContext
    {
        public SeminarHubDbContext(DbContextOptions<SeminarHubDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SeminarParticipant>()
                .HasKey(sp => new { sp.SeminarId, sp.ParticipantId });

            builder.Entity<SeminarParticipant>()
                .HasOne(sp => sp.Seminar)
                .WithMany(s => s.SeminarParticipants)
                .HasForeignKey(sp => sp.SeminarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Category>()
                .HasData(new Category()
                    {
                        Id = 1,
                        Name = "Technology & Innovation"
                    },
                    new Category()
                    {
                        Id = 2,
                        Name = "Business & Entrepreneurship"
                    },
                    new Category()
                    {
                        Id = 3,
                        Name = "Science & Research"
                    },
                    new Category()
                    {
                        Id = 4,
                        Name = "Arts & Culture"
                    });
        }

        public DbSet<Seminar> Seminars { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SeminarParticipant> SeminarParticipants { get; set; }
    }
}