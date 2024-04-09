using System.ComponentModel.DataAnnotations;
using static Contacts.Data.Constants.DataConstants;

namespace Contacts.Data.Models;

public class Contact
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ContactFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(ContactLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [Required]
    [MaxLength(ContactEmailMaxLength)]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(ContactPhoneNumberMaxLength)]
    public string PhoneNumber { get; set; } = null!;

    public string? Address { get; set; }

    [Required]
    public string Website { get; set; } = null!;

    public IEnumerable<ApplicationUserContact> ApplicationUsersContacts { get; set; } =
        new List<ApplicationUserContact>();
}