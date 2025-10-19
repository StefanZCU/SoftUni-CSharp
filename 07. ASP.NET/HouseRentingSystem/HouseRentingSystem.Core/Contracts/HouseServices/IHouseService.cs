using HouseRentingSystem.Core.Enumerators;
using HouseRentingSystem.Core.Models.HouseModels;
using HouseRentingSystem.Core.Services.HouseServices;

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
    
    Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId);
    
    Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId);
    
    Task<bool> ExistsAsync(int id);
    
    Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id);
    
}