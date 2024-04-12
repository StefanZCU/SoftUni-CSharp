using HouseRentingSystem.Core.Enumerations;
using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts;

public interface IHouseService
{
    Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync();

    Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync();

    Task<bool> CategoryExistsAsync(int categoryId);

    Task<int> CreateAsync(HouseFormModel model, int agentId);

    Task<HouseQueryServiceModel> AllAsync(
        string? category = null,
        string? searchTerm = null, 
        HouseSorting sorting = HouseSorting.Newest,
        int currentPage = 1,
        int housePerPage = 1);

    Task<IEnumerable<string>> AllCategoriesNamesAsync();

    Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId);
    Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId);

    Task<bool> ExistsAsync(int id);
    Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id);

    Task EditAsync(HouseFormModel model, int houseId);

    Task<bool> HasAgentWithIdAsync(int houseId, string currentUserId);

    Task<HouseFormModel?> GetHouseFormModelByIdAsync(int id);

    Task DeleteAsync(int houseId);

    Task<bool> IsRentedAsync(int id);

    Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId);

    Task RentAsync(int houseId, string userId);

    Task LeaveAsync(int houseId);
}