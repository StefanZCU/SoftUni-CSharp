using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Data.DataConstants;
using static SoftUniBazar.Data.ErrorConstants;

namespace SoftUniBazar.Models;

public class CategoryViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength,
        ErrorMessage = StringLengthErrorMessage)]
    public string Name { get; set; } = null!;
}