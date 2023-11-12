namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Game
{
    [Key]
    public int GameId { get; set; }

    public int HomeTeamId { get; set; }

    public int AwayTeamId { get; set; }

    public byte HomeTeamGoals { get; set; }

    public byte AwayTeamGoals { get; set; }

    public DateTime DateTime { get; set; }

    public decimal HomeTeamBetRate { get; set; }

    public decimal AwayTeamBetRate { get; set; }

    public decimal DrawBetRate { get; set; }

    [MaxLength(ValidationConstants.GameResultMaxLength)]
    public string? Result { get; set; }

}