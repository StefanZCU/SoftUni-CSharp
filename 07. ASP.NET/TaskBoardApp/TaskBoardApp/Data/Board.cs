using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static TaskBoardApp.Data.DataConstants;

namespace TaskBoardApp.Data;

public class Board
{
    [Key]
    [Comment("Board ID")]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(BoardNameMaximumLength)]
    [Comment("Board Name")]
    public required string Name { get; set; }

    public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
}