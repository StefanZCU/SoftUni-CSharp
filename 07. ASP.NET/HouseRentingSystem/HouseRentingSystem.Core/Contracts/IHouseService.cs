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
    
    Task EditAsync(int houseId, HouseFormModel model);

    Task<bool> HasAgentWithIdAsync(int houseId, string currentUserId);
    
    Task<HouseFormModel?> GetHouseFormModelByIdAsync(int id);
    
    Task DeleteAsync(int houseId);
    
    Task<bool> IsRentedAsync(int houseId);
    
    Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId);
    
    Task RentAsync(int houseId, string userId);
    
    Task LeaveAsync(int houseId, string userId);
    
    Task<IEnumerable<HouseServiceModel>> GetUnapprovedHousesAsync();

    Task ApproveHouseAsync(int houseId);
}