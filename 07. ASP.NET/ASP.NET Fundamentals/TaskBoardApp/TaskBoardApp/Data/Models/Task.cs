using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Data.Models;

public class Task
{
    public int Id { get; set; }

    [Required]
    [MaxLength(TaskMaxTitle)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(TaskMaxDescription)]
    public string Description { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int BoardId { get; set; }

    public Board? Board { get; set; }

    [Required] 
    public string OwnerId { get; set; } = null!;

    public IdentityUser User { get; set; } = null!;
}