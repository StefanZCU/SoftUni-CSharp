using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts;

public interface IHouseService
{
    Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();
}