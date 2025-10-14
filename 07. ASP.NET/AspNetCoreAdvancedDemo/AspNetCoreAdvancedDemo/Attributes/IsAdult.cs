using System.ComponentModel.DataAnnotations;

namespace AspNetCoreAdvancedDemo.Attributes;

public class IsAdult : ValidationAttribute
{
    private readonly DateTime _minimumAge;
    private int _age;

    public IsAdult(int age)
    {
        _age = age;
        _minimumAge = DateTime.Today.AddYears(age * -1);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null && (DateTime)value <= _minimumAge)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult($"You must be at least {_age} years old to participate in this event.");
    }
}