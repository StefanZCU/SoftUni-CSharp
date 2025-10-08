namespace TaskBoardApp.Models;

public class TaskDetailsViewModel : TaskViewModel
{
    public string CreatedOn { get; init; } = null!;

    public string Board { get; set; } = null!;
}