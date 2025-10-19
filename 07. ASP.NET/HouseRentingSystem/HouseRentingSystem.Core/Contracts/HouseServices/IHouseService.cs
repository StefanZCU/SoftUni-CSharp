using HouseRentingSystem.Core.Enumerators;
using HouseRentingSystem.Core.Models.HouseModels;

namespace HouseRentingSystem.Core.Contracts.HouseServices;

public interface IHouseService
{
    Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();
    
    Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync();
    
    Task<bool> CategoryExistsAsync(int categoryId);

    Task<int> CreateAsync(HouseFormModel model, int agentId);

    Task<HouseQueryServiceModel> AllAsync(string? category = null,
        string? searchTerm = null,
        HouseSorting sorting = HouseSorting.Newest,
        int currentPage = 1,
        int housesPerPage = 1);
    
    Task<IEnumerable<string>> AllCategoriesNamesAsync();
}