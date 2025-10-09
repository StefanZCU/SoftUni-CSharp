using System.ComponentModel.DataAnnotations;
using static GameZone.Common.Constants.DataConstants;
using static GameZone.Common.Constants.ErrorConstants;

namespace GameZone.Models.GenreViewModels;

public class GenreViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(maximumLength: GenreNameMaxLength,
        MinimumLength = GenreNameMinLength,
        ErrorMessage = FieldLengthError)]
    public string Name { get; set; } = null!;
}