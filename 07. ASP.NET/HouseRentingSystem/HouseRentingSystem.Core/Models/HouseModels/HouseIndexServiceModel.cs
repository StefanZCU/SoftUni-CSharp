using HouseRentingSystem.Core.Contracts;

namespace HouseRentingSystem.Core.Models.HouseModels;

public class HouseIndexServiceModel : IHouseModel
{
    public int Id { get; set; }

    public required string Title { get; set; }
    
    public required string Address { get; set; }

    public required string ImageUrl { get; set; }
}