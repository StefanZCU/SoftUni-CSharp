namespace GameZone.Common.Constants;
using static DataConstants;

public static class ErrorConstants
{
    public const string RequiredFieldError = "The {0} field is required.";
    
    public const string FieldLengthError = "The {0} field must be between {2} and {1} characters.";
    
    public const string InvalidDateFormatError = $"Invalid date format! You must use {DateFormat}.";
    
    public const string GenreDoesNotExistError = "Genre does not exist.";
}