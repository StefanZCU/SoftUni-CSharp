namespace TaskBoardApp.Models;

public class HomeViewModel
{
    public int AllTasksCount { get; set; }

    public List<HomeBoardViewModel> BoardsWithTasksCount { get; set; } = null!;

    public int UserTasksCount { get; set; }
}