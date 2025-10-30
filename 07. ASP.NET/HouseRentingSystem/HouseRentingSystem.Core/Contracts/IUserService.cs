using HouseRentingSystem.Core.Models.AdminModels.User;

namespace HouseRentingSystem.Core.Contracts.UserServices;

public interface IUserService
{
    Task<string> UserFullNameAsync(string userId);
    
    Task<IEnumerable<UserServiceModel>> AllAsync();
}