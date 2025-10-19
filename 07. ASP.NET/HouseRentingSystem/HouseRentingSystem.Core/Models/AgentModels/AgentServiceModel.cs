using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.AgentModels;

public class AgentServiceModel
{
    [Display(Name = "Phone Number")]
    public required string PhoneNumber { get; set; }

    public required string Email { get; set; }
}