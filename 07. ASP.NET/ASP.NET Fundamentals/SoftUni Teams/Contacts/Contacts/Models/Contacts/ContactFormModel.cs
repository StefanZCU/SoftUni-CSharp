using System.ComponentModel.DataAnnotations;
using static Contacts.Data.Constants.DataConstants;
using static Contacts.Data.Constants.ErrorConstants;

namespace Contacts.Models.Contacts;

public class ContactFormModel
{
    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(ContactFirstNameMaxLength, MinimumLength = ContactFirstNameMinLength,
        ErrorMessage = WrongLengthFieldError)]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(ContactLastNameMaxLength, MinimumLength = ContactLastNameMinLength,
        ErrorMessage = WrongLengthFieldError)]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(ContactEmailMaxLength, MinimumLength = ContactEmailMinLength,
        ErrorMessage = WrongLengthFieldError)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [RegularExpression(ContactPhoneNumberRegEx, ErrorMessage = WrongFormatError)]
    [StringLength(ContactPhoneNumberMaxLength, MinimumLength = ContactPhoneNumberMinLength,
        ErrorMessage = WrongLengthFieldError)]
    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }

    [Required(ErrorMessage = RequiredFieldError)]
    [RegularExpression(ContactWebsiteRegEx, ErrorMessage = WrongFormatError)]
    public string Website { get; set; } = null!;
}