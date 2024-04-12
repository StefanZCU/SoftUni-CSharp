using HouseRentingSystem.Core.Enumerations;
using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts;

public interface IHouseService
{
    Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();

    Task<IEnumerable<HouseCategoryServiceModel>> AllCategories();

    Task<bool> CategoryExistsAsync(int categoryId);

    Task<int> CreateAsync(HouseFormModel model, int agentId);

    Task<HouseQueryServiceModel> AllAsync(
        string? category = null,
        string? searchTerm = null, 
        HouseSorting sorting = HouseSorting.Newest,
        int currentPage = 1,
        int housePerPage = 1);

    Task<IEnumerable<string>> AllCategoriesNamesAsync();

    Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int agentId);
    Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId);

    Task<bool> ExistsAsync(int id);
    Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id);
}