namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Town
{
    [Key]
    public int TownId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.TownNameMaxLength)]
    public string Name { get; set; }


    public int CountryId { get; set; }

}