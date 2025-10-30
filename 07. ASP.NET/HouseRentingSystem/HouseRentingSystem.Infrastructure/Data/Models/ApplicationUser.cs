using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(UserFirstNameMaxLength)]
    [PersonalData]
    public required string FirstName { get; set; }

    [Required]
    [MaxLength(UserLastNameMaxLength)]
    [PersonalData]
    public required string LastName { get; set; }

    public Agent? Agent { get; set; } 
}