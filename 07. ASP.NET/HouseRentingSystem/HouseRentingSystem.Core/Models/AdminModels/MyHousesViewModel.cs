using HouseRentingSystem.Core.Models.HouseModels;

namespace HouseRentingSystem.Core.Models.AdminModels;

public class MyHousesViewModel
{
    public IEnumerable<HouseServiceModel> AddedHouses { get; set; } = new List<HouseServiceModel>();
    
    public IEnumerable<HouseServiceModel> RentedHouses { get; set; } = new List<HouseServiceModel>();
}