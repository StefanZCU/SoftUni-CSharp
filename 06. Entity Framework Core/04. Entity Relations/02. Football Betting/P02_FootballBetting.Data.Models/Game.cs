namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Game
{
    public Game()
    {
        PlayersStatistics = new HashSet<PlayerStatistic>();
        Bets = new HashSet<Bet>();
    }

    [Key]
    public int GameId { get; set; }

    [ForeignKey(nameof(HomeTeam))]
    public int HomeTeamId { get; set; }

    public virtual Team HomeTeam { get; set; } = null!;

    [ForeignKey(nameof(AwayTeam))]
    public int AwayTeamId { get; set; }

    public virtual Team AwayTeam { get; set; } = null!;

    public byte HomeTeamGoals { get; set; }

    public byte AwayTeamGoals { get; set; }

    public DateTime DateTime { get; set; }

    public decimal HomeTeamBetRate { get; set; }

    public decimal AwayTeamBetRate { get; set; }

    public decimal DrawBetRate { get; set; }

    [MaxLength(ValidationConstants.GameResultMaxLength)]
    public string? Result { get; set; }

    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }

    public virtual ICollection<Bet> Bets { get; set; }

}