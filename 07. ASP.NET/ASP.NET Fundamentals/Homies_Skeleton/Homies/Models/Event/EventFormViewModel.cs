using System.ComponentModel.DataAnnotations;
using Homies.Models.Type;
using static Homies.Data.DataConstants;
using static Homies.Models.ErrorConstants;

namespace Homies.Models.Event;

public class EventFormViewModel
{
    [Required(ErrorMessage = RequireErrorMessage)]
    [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength, ErrorMessage = StringLengthErrorMessage)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = RequireErrorMessage)]
    [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength,
        ErrorMessage = StringLengthErrorMessage)]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = RequireErrorMessage)] 
    public string Start { get; set; } = string.Empty;

    [Required(ErrorMessage = RequireErrorMessage)] 
    public string End { get; set; } = string.Empty;

    [Required(ErrorMessage = RequireErrorMessage)]
    public int TypeId { get; set; }

    public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
}