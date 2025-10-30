namespace HouseRentingSystem.Core.Models.AdminModels;

public class RentServiceModel
{
    public required string HouseTitle { get; set; }

    public required string HouseImageURL { get; set; }

    public required string AgentFullName { get; set; }

    public required string AgentEmail { get; set; }

    public required string RenterFullName { get; set; }

    public required string RenterEmail { get; set; }
}