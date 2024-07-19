using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts.House;

public interface IHouseService
{
    Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();
}