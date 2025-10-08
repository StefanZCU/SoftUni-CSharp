using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants;
using static Homies.Models.ErrorMessages;

namespace Homies.Models;

public class EventFormViewModel
{
    [Required(ErrorMessage = EventFieldRequiredErrorMessage)]
    [StringLength(maximumLength: EventNameMaxLength, MinimumLength = EventNameMinLength,
        ErrorMessage = EventFieldLengthErrorMessage)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = EventFieldRequiredErrorMessage)]
    [StringLength(maximumLength: EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength,
        ErrorMessage = EventFieldLengthErrorMessage)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = EventFieldRequiredErrorMessage)]
    public string Start { get; set; } = null!;

    [Required(ErrorMessage = EventFieldRequiredErrorMessage)]
    public string End { get; set; } = null!;
    
    [Required(ErrorMessage = EventFieldRequiredErrorMessage)]
    public int TypeId { get; set; }

    public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
}