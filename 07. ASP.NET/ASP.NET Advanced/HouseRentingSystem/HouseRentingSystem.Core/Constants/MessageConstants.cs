namespace HouseRentingSystem.Core.Constants;

public static class MessageConstants
{
    public const string RequiredErrorMessage = "The {0} field is required";

    public const string LengthMessage = "The field {0} must be between {2} and {1} characters long";

   public const string PhoneExists = "Phone number already exists. Enter another one.";

   public const string HasRents = "You cannot become an agent if you have active rents.";
}