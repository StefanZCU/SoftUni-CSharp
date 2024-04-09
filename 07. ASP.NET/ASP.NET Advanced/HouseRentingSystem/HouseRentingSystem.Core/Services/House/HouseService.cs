using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services.House;

public class HouseService : IHouseService
{
    private readonly IRepository _repository;

    public HouseService(IRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
    {
        return await _repository
            .AllReadOnly<Infrastructure.Data.Models.House>()
            .OrderByDescending(h => h.Id)
            .Take(3)
            .Select(h => new HouseIndexServiceModel()
            {
                Id = h.Id,
                Title = h.Title,
                ImageUrl = h.ImageUrl
            })
            .ToListAsync();
    }
}