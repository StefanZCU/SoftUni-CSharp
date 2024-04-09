namespace Contacts.Data.Constants;

public static class DataConstants
{
    public const int ContactFirstNameMaxLength = 50;
    public const int ContactFirstNameMinLength = 2;
    
    public const int ContactLastNameMaxLength = 50;
    public const int ContactLastNameMinLength = 5;
    
    public const int ContactEmailMaxLength = 60;
    public const int ContactEmailMinLength = 10;

    public const int ContactPhoneNumberMaxLength = 13;
    public const int ContactPhoneNumberMinLength = 10;

    public const string ContactPhoneNumberRegEx = @"^(\+359|0)[-\s]?[0-9]{3}[-\s]?[0-9]{2}[-\s]?[0-9]{2}[-\s]?[0-9]{2}$";
    public const string ContactWebsiteRegEx = @"^www\.[a-zA-Z0-9-]*\.bg$";
}