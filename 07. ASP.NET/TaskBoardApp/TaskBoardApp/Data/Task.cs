using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static TaskBoardApp.Data.DataConstants;

namespace TaskBoardApp.Data;

[Comment("Board tasks")]
public class Task
{
    [Key]
    [Comment("Task ID")]
    public int Id { get; set; }

    [Required]
    [MaxLength(TaskTitleMaximumLength)]
    [Comment("Task Name")]
    public required string Title { get; set; }

    [Required]
    [MaxLength(TaskDescriptionMaximumLength)]
    [Comment("Task Description")]
    public required string Description { get; set; }

    [Comment("Date of creation")]
    public DateTime? CreatedOn { get; set; }

    [Comment("Board ID")]
    public int? BoardId { get; set; }

    [Required]
    [Comment("Application user ID")]
    public required string OwnerId { get; set; }

    [ForeignKey(nameof(BoardId))]
    public Board? Board { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public IdentityUser Owner { get; set; } = null!;
}