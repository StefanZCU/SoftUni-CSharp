using HouseRentingSystem.Core.Models.AgentModels;

namespace HouseRentingSystem.Core.Models.HouseModels;

public class HouseDetailsServiceModel : HouseServiceModel
{
    public required string Description { get; set; }

    public required string Category { get; set; }

    public required AgentServiceModel Agent { get; set; }
}