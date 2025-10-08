using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants;

namespace TaskBoardApp.Models;

public class TaskViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(maximumLength: TaskTitleMaximumLength, MinimumLength = TaskTitleMinimumLength)]
    public required string Title { get; set; }

    [Required]
    [StringLength(maximumLength: TaskDescriptionMaximumLength, MinimumLength = TaskDescriptionMinimumLength)]
    public required string Description { get; set; }

    public string Owner { get; set; }
}