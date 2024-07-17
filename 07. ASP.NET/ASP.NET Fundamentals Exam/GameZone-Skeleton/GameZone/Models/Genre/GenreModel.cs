using System.ComponentModel.DataAnnotations;
using static GameZone.Common.Constants.DataConstants;
using static GameZone.Common.Constants.ErrorConstants;

namespace GameZone.Models.Genre;

public class GenreModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(GenreNameMaxLength, MinimumLength = GenreNameMinLength, ErrorMessage = RequiredFieldError)]
    public string Name { get; set; } = null!;
}