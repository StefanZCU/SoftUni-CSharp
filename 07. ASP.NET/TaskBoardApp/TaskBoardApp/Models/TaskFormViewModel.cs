using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants;

namespace TaskBoardApp.Models;

public class TaskFormViewModel
{
    [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
    [StringLength(maximumLength: TaskTitleMaximumLength, MinimumLength = TaskTitleMinimumLength,
        ErrorMessage = ErrorMessages.StringLengthErrorMessage)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
    [StringLength(maximumLength: TaskDescriptionMaximumLength, MinimumLength = TaskDescriptionMinimumLength,
        ErrorMessage = ErrorMessages.StringLengthErrorMessage)]
    public string Description { get; set; } = null!;

    [Display(Name = "Board")]
    public int BoardId { get; set; }

    public IEnumerable<TaskBoardViewModel> Boards { get; set; } = new List<TaskBoardViewModel>();
}