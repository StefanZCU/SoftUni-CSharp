using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.Agent;

public class AgentServiceModel
{
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;
}