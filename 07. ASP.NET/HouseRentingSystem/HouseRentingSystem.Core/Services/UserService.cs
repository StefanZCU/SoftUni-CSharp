using HouseRentingSystem.Core.Contracts.UserServices;
using HouseRentingSystem.Core.Models.AdminModels.User;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services.UserServices;

public class UserService : IUserService
{
    private readonly IRepository _repository;

    public UserService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> UserFullNameAsync(string userId)
    {
        var result = string.Empty;
        var user = await _repository
            .GetByIdAsync<ApplicationUser>(userId);

        if (user != null)
        {
            result = $"{user.FirstName} {user.LastName}";
        }

        return result;
    }

    public async Task<IEnumerable<UserServiceModel>> AllAsync()
    {
        return await _repository
            .AllReadOnly<ApplicationUser>()
            .Include(u => u.Agent)
            .Select(u => new UserServiceModel()
            {
                Email = u.Email,
                FullName = $"{u.FirstName} {u.LastName}",
                PhoneNumber = u.Agent != null ? u.Agent.PhoneNumber : null,
                IsAgent = u.Agent != null
            })
            .OrderByDescending(u => u.IsAgent)
            .ToListAsync();
    }
}