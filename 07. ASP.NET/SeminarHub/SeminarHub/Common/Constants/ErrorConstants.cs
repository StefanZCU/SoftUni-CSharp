namespace SeminarHub.Common.Constants;
using static DataConstants;

public class ErrorConstants
{
    public const string RequiredFieldError = "The {0} field is required.";

    public const string FieldLengthError = "The {0} field must be between {2} and {1} characters.";
    
    public const string DurationFieldLengthError = "The {0} field must be between {1} and {2} characters.";
    
    public const string InvalidDateFormatError = $"Invalid date format. The format must be: {DateFormat}";
    
    public const string CategoryDoesntExistError = "Category doesn't exist";
}