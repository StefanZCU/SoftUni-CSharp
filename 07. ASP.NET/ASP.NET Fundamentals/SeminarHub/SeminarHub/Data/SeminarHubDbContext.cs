using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
            //builder
            //   .Entity<Category>()
            //   .HasData(new Category()
            //   {
            //       Id = 1,
            //       Name = "Technology & Innovation"
            //   },
            //   new Category()
            //   {
            //       Id = 2,
            //       Name = "Business & Entrepreneurship"
            //   },
            //   new Category()
            //   {
            //       Id = 3,
            //       Name = "Science & Research"
            //   },
            //   new Category()
            //   {
            //       Id = 4,
            //       Name = "Arts & Culture"
            //   });

            base.OnModelCreating(builder);
        }
    }
}