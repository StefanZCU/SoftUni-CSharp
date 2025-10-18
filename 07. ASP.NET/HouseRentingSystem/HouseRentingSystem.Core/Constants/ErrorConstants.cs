namespace HouseRentingSystem.Core.Constants;

public static class ErrorConstants
{
    public const string RequiredFieldError = "The {0} field is required.";
    
    public const string InvalidFieldLengthError = "The {0} field must be between {2} and {1} characters long.";
    
    public const string InvalidPricePerMonthError = "The price per month must be a positive number and less than {2} leva.";
    
}