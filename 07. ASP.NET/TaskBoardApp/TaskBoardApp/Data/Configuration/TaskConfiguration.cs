using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskBoardApp.Data.Configuration;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder
            .HasOne(t => t.Board)
            .WithMany(t => t.Tasks)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(SeedTasks());
    }
    
    private IEnumerable<Task> SeedTasks()
    {
        IEnumerable<Task> tasks =
        [
            new Task()
            {
                Id = 1,
                Title = "Improve CSS styles",
                Description = "Implement better styling for all public pages",
                CreatedOn = DateTime.Now.AddDays(-200),
                OwnerId = ConfigurationHelper.TestUser.Id,
                BoardId = ConfigurationHelper.OpenBoard.Id
            },
            new Task()
            {
                Id = 2,
                Title = "Android Client App",
                Description = "Create Android client app for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddMonths(-5),
                OwnerId = ConfigurationHelper.TestUser.Id,
                BoardId = ConfigurationHelper.OpenBoard.Id
            },
            new Task()
            {
                Id = 3,
                Title = "Desktop Client App",
                Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddMonths(-1),
                OwnerId = ConfigurationHelper.TestUser.Id,
                BoardId = ConfigurationHelper.InProgressBoard.Id
            },
            new Task()
            {
                Id = 4,
                Title = "Create Tasks",
                Description = "Implement [Create Task] page for adding new tasks",
                CreatedOn = DateTime.Now.AddYears(-1),
                OwnerId = ConfigurationHelper.TestUser.Id,
                BoardId = ConfigurationHelper.DoneBoard.Id
            },

        ];
        
        return tasks;
    }
}