using HouseRentingSystem.Core.Models.HouseModels;

namespace HouseRentingSystem.Core.Contracts.HouseServices;

public interface IHouseService
{
    Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();
    
    Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync();
    
    Task<bool> CategoryExistsAsync(int categoryId);

    Task<int> CreateAsync(HouseFormModel model, int agentId);
}