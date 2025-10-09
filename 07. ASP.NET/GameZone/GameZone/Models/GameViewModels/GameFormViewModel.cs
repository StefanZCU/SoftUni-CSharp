using System.ComponentModel.DataAnnotations;
using GameZone.Data.Models;
using GameZone.Models.GenreViewModels;
using static GameZone.Common.Constants.DataConstants;
using static GameZone.Common.Constants.ErrorConstants;

namespace GameZone.Models.GameViewModels;

public class GameFormViewModel
{
    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(maximumLength: GameTitleMaxLength,
        MinimumLength = GameTitleMinLength,
        ErrorMessage = FieldLengthError)]
    public string Title { get; set; } = null!;

    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(maximumLength: GameDescriptionMaxLength,
        MinimumLength = GameDescriptionMinLength,
        ErrorMessage = FieldLengthError)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [Display(Name = "Release Date")]
    public string ReleasedOn { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [Display(Name = "Genre")]
    public int GenreId { get; set; }

    public IEnumerable<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
}