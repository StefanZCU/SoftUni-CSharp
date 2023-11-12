namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Country
{
    [Key]
    public int CountryId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.CountryNameMaxLength)]
    public string Name { get; set; }

}