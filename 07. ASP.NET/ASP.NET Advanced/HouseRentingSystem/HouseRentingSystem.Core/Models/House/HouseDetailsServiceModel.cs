using HouseRentingSystem.Core.Models.Agent;

namespace HouseRentingSystem.Core.Models.House;

public class HouseDetailsServiceModel : HouseServiceModel
{
    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public AgentServiceModel Agent { get; set; } = null!;
}