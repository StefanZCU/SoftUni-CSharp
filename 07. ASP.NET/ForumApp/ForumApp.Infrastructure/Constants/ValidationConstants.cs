namespace ForumApp.Infrastructure.Constants;

/// <summary>
/// Constants used for model validation
/// </summary>
public static class ValidationConstants
{
    //Post
    public const int PostTitleMaxLength = 50;
    public const int PostTitleMinLength = 10;
    
    public const int PostContentMaxLength = 1500;
    public const int PostContentMinLength = 30;


    
    public const string RequiredFieldErrorMessage = "The {0} field is required.";
    public const string FieldLengthErrorMessage = "The {0} field must be between {2} and {1} characters long.";
}