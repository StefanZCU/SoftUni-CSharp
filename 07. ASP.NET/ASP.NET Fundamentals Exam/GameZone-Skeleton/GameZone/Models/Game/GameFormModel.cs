using GameZone.Models.Genre;
using System.ComponentModel.DataAnnotations;
using static GameZone.Common.Constants.DataConstants;
using static GameZone.Common.Constants.ErrorConstants;

namespace GameZone.Models.Game;

public class GameFormModel
{
    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(GameTitleMaxLength, MinimumLength = GameTitleMinLength, ErrorMessage = FieldLengthError)]
    public string Title { get; set; } = null!;
    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(GameDescriptionMaxLength, MinimumLength = GameDescriptionMinLength, ErrorMessage = FieldLengthError)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [Display(Name = "Release Date")]
    public string ReleasedOn { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [Display(Name = "Genre")]
    public int GenreId { get; set; }

    public IEnumerable<GenreModel> Genres { get; set; } = new List<GenreModel>();
}