using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AspNetCoreAdvancedDemo.Attributes;

public class IsBefore : ValidationAttribute
{
    private const string DateTimeFormat = "dd/MM/yyyy";
    private readonly DateTime _date;

    public IsBefore(string dateInput)
    {
        _date = DateTime.ParseExact(dateInput, DateTimeFormat, CultureInfo.InvariantCulture);
    }

    public string DatePurpose { get; set; }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null && (DateTime)value >= _date)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}