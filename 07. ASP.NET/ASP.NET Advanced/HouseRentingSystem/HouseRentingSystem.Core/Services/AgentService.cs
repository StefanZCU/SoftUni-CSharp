using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services;

public class AgentService : IAgentService
{
    private readonly IRepository _repository;

    public AgentService(IRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> ExistByIdAsync(string userId)
    {
        return await 
            _repository
                .AllReadOnly<Agent>()
                .AnyAsync(a => a.UserId == userId);
    }

    public Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserHasRentsAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(string userId, string phoneNumber)
    {
        throw new NotImplementedException();
    }
}