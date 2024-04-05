using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Data.DataConstants;
using static SoftUniBazar.Data.ErrorConstants;

namespace SoftUniBazar.Models;

public class AdFormViewModel
{
    [Required(ErrorMessage = RequireErrorMessage)]
    [StringLength(AdNameMaxLength, MinimumLength = AdNameMinLength, ErrorMessage = StringLengthErrorMessage)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = RequireErrorMessage)]
    [StringLength(AdDescriptionMaxLength, MinimumLength = AdDescriptionMinLength, ErrorMessage = StringLengthErrorMessage)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = RequireErrorMessage)]
    public string ImageUrl { get; set; } = null!;

    [Required(ErrorMessage = RequireErrorMessage)]
    public decimal Price { get; set; }

    [Required(ErrorMessage = RequireErrorMessage)]
    public int CategoryId { get; set; }

    public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
}