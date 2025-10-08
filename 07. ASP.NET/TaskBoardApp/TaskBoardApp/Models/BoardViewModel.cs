using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants;

namespace TaskBoardApp.Models;

public class BoardViewModel
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(maximumLength: BoardNameMaximumLength, MinimumLength = BoardNameMinimumLength)]
    public required string Name { get; set; }

    public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
}