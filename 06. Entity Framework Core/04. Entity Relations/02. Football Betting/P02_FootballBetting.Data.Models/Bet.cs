namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Enums;

public class Bet
{
    [Key]
    public int BetId { get; set; }

    public decimal Amount { get; set; }

    public Prediction Prediction { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }

    public int GameId { get; set; }
}