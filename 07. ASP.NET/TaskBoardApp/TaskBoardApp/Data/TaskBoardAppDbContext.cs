using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Configuration;

namespace TaskBoardApp.Data;

public class TaskBoardAppDbContext : IdentityDbContext
{
    public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Task> Tasks { get; set; }

    public DbSet<Board> Boards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new BoardConfiguration());
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}