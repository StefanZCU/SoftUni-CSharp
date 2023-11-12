namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Color
{
    public Color()
    {
        PrimaryKitTeams = new HashSet<Team>();
        SecondaryKitTeams = new HashSet<Team>();
    }

    [Key]
    public int ColorId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ColorNameMaxLength)]
    public string Name { get; set; }

    public virtual ICollection<Team> PrimaryKitTeams { get; set; }

    public virtual ICollection<Team> SecondaryKitTeams { get; set; }

}