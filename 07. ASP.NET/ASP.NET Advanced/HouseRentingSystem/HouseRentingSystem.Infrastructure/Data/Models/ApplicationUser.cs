using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(UserFirstNameMaxLength)]
    [PersonalData]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(UserLastNameMaxLength)]
    [PersonalData]
    public string LastName { get; set; } = null!;
}