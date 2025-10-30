using HouseRentingSystem.Core.Models.AdminModels;

namespace HouseRentingSystem.Core.Contracts;

public interface IRentService
{
    Task<IEnumerable<RentServiceModel>> AllAsync();
}