using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.AdminModels.User;

public class UserServiceModel
{
    public required string Email { get; set; }

    [Display(Name = "Full Name")]
    public required string FullName { get; set; }

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    public bool IsAgent { get; set; }
}