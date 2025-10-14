using HouseRentingSystem.Core.Models.HouseModels;

namespace HouseRentingSystem.Core.Contracts.HouseServices;

public interface IHouseService
{
    Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();
}