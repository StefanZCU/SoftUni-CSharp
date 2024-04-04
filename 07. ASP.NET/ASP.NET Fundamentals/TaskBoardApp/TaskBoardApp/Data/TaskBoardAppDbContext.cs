using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data;

public class TaskBoardAppDbContext : IdentityDbContext<IdentityUser>
{
    
    private IdentityUser TestUser { get; set; }
    private Board OpenBoard { get; set; }
    private Board InProgressBoard { get; set; }
    private Board DoneBoard { get; set; }
    
    public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    public DbSet<Board> Boards { get; set; }

    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Task>()
            .HasOne(t => t.Board)
            .WithMany(b => b.Tasks)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        SeedUsers();
        builder.Entity<IdentityUser>()
            .HasData(TestUser);

        SeedBoards();
        builder.Entity<Board>()
            .HasData(OpenBoard, InProgressBoard, DoneBoard);

        builder
            .Entity<Task>()
            .HasData(
            new Task()
            {
                Id = 1,
                Title = "Android Client App",
                Description = "Create Android client app for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddMonths(-5),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            },
            new Task()
            {
                Id = 2,
                Title = "Improve CSS styles",
                Description = "Implement better styling for all public pages",
                CreatedOn = DateTime.Now.AddDays(-200),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            },
            new Task()
            {
                Id = 3,
                Title = "Desktop Client App",
                Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddMonths(-1),
                OwnerId = TestUser.Id,
                BoardId = InProgressBoard.Id
            },
            new Task()
            {
                Id = 4,
                Title = "Create Tasks",
                Description = "Implement [Create Task] page for adding new tasks",
                CreatedOn = DateTime.Now.AddYears(-1),
                OwnerId = TestUser.Id,
                BoardId = DoneBoard.Id
            });
        
        base.OnModelCreating(builder);
    }

    private void SeedUsers()
    {
        var hasher = new PasswordHasher<IdentityUser>();

        TestUser = new IdentityUser()
        {
            UserName = "test@softuni.bg",
            NormalizedUserName = "TEST@SOFTUNI.BG"
        };

        TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");
    }

    private void SeedBoards()
    {
        OpenBoard = new Board()
        {
            Id = 1,
            Name = "Open"
        };

        InProgressBoard = new Board()
        {
            Id = 2,
            Name = "In Progress"
        };

        DoneBoard = new Board()
        {
            Id = 3,
            Name = "Done"
        };
    }
    
}