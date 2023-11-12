using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Team
{
    [Key]
    public int TeamId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.TeamNameMaxLength)]
    public string Name { get; set; }

    [MaxLength(ValidationConstants.TeamLogoUrlMaxLength)]
    public string LogoUrl { get; set; }

    [Required]
    [MaxLength(ValidationConstants.TeamInitialsMaxLength)]
    public string Initials { get; set; }

    public decimal Budget { get; set; }

    [ForeignKey(nameof(PrimaryKitColor))]
    public int PrimaryKitColorId { get; set; }

    public virtual Color PrimaryKitColor { get; set; }

    [ForeignKey(nameof(SecondaryKitColor))]
    public int SecondaryKitColorId { get; set; }

    public virtual Color SecondaryKitColor { get; set; }

    public int TownId { get; set; }

}