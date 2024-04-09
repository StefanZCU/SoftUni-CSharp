using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Contacts.Data.Models;

public class ApplicationUserContact
{
    [Required]
    public string ApplicationUserId { get; set; } = null!;

    [ForeignKey(nameof(ApplicationUserId))]
    public IdentityUser ApplicationUser { get; set; } = null!;

    [Required]
    public int ContactId { get; set; }

    [ForeignKey(nameof(ContactId))]
    public Contact Contact { get; set; } = null!;
}