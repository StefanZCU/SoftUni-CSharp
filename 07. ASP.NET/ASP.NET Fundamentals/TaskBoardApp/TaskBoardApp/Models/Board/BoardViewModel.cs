using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Models.Board;

public class BoardViewModel
{
    public int Id { get; init; }

    public string Name { get; set; } = null!;

    public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
}