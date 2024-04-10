namespace HouseRentingSystem.Core.Constants;

public static class MessageConstants
{
    public const string RequiredErrorMessage = "The {0} field is required";

    public const string StringFieldLengthErrorMessage = "The {0} field must be between {2} and {1} characters long";

    public const string PricePerMonthErrorMessage = "Price Per Month must be a positive number and less than {2} leva.";

    public const string PhoneExists = "Phone number already exists. Enter another one.";

    public const string HasRents = "You should have no rents to become and agent!";

    public const string CategoryDoesNotExist = "Category does not exist.";
}