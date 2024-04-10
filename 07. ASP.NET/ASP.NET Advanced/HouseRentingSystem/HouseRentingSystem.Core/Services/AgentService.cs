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

    public async Task<int?> GetAgentIdAsync(string userId)
    {
        return (await _repository.AllReadOnly<Agent>().FirstOrDefaultAsync(a => a.UserId == userId))?.Id;
    }

    public async Task<bool> ExistByIdAsync(string userId)
    {
        return await
            _repository
                .AllReadOnly<Agent>()
                .AnyAsync(a => a.UserId == userId);
    }

    public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
    {
        return await
            _repository
                .AllReadOnly<Agent>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
    }

    public async Task<bool> UserHasRentsAsync(string userId)
    {
        return await
            _repository
                .AllReadOnly<House>()
                .AnyAsync(h => h.RenterId == userId);
    }

    public async Task CreateAsync(string userId, string phoneNumber)
    {
        await _repository
            .AddAsync(new Agent()
            {
                PhoneNumber = phoneNumber,
                UserId = userId
            });

        await _repository.SaveChangesAsync();
    }
}