using System.ComponentModel.DataAnnotations;
using AspNetCoreAdvancedDemo.Attributes;

namespace AspNetCoreAdvancedDemo.Models;

public class HomeViewModel : IValidatableObject
{
    [IsAdult(18, ErrorMessage = $"You must be at least 18 years old")]
    public DateTime BirthDate { get; set; }
    
    public string? Name { get; set; }

    public string? Country { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Name))
        {
            yield return new ValidationResult("Name is required");
        }
        
        if (string.IsNullOrEmpty(Country))
        {
            yield return new ValidationResult("Country is required");
        }

        if (Name != "Pesho" && Country != "Bulgaria")
        {
            yield return new ValidationResult("If your name is Pesho, Country must be Bulgaria");
        }
    }
}