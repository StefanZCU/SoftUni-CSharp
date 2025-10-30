using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.AdminModels;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services;

public class RentService : IRentService
{
    private readonly IRepository _repository;

    public RentService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<RentServiceModel>> AllAsync()
    {
        return await _repository
            .AllReadOnly<House>()
            .Where(h => h.RenterId != null)
            .Include(h => h.Agent)
            .Include(h => h.Renter)
            .Select(h => new RentServiceModel()
            {
                AgentEmail = h.Agent.User.Email,
                AgentFullName = $"{h.Agent.User.FirstName} {h.Agent.User.LastName}",
                HouseImageURL = h.ImageUrl,
                HouseTitle = h.Title,
                RenterEmail = h.Renter.Email,
                RenterFullName = $"{h.Renter.FirstName} {h.Renter.LastName}"
            })
            .ToListAsync();
    }
}