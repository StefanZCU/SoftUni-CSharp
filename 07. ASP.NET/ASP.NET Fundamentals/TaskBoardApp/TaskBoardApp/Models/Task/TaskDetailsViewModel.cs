namespace TaskBoardApp.Models.Task;

public class TaskDetailsViewModel : TaskViewModel
{
    public string CreatedOn { get; init; } = null!;

    public string Board { get; init; } = null!;
}