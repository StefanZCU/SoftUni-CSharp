using System.ComponentModel.DataAnnotations;
using static SeminarHub.Common.Constants.DataConstants;
using static SeminarHub.Common.Constants.ErrorConstants;

namespace SeminarHub.Models.CategoryModels;

public class CategoryViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(maximumLength: CategoryNameMaxLength,
        MinimumLength = CategoryNameMinLength,
        ErrorMessage = FieldLengthError)]
    public string Name { get; set; } = null!;
}