using Microsoft.EntityFrameworkCore;
using ForumApp.Infrastructure.Data.Models;
using ForumApp.Infrastructure.Data.Configuration;

namespace ForumApp.Infrastructure.Data;

public class ForumAppDbContext : DbContext
{
    public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Post> Posts { get; set; }
}