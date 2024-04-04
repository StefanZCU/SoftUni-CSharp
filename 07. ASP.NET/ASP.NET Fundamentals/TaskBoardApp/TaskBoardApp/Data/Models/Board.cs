using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.Board;

namespace TaskBoardApp.Data.Models;

public class Board
{
    public int Id { get; init; }

    [Required] 
    [MaxLength(BoardMaxName)] 
    public string Name { get; init; } = null!;

    public IEnumerable<Task> Tasks { get; set; } = new List<Task>();

}