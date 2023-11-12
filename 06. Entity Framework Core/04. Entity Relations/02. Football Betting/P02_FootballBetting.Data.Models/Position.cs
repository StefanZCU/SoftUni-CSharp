namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Position
{
    [Key]
    public int PositionId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PositionNameMaxLength)]
    public string Name { get; set; }
}