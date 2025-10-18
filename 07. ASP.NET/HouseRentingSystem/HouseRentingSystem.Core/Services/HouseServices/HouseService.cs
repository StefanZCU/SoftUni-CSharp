using HouseRentingSystem.Core.Contracts.HouseServices;
using HouseRentingSystem.Core.Models.HouseModels;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services.HouseServices;

public class HouseService : IHouseService
{
    private readonly IRepository _repository;

    public HouseService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHousesAsync()
    {
        return await _repository
            .AllReadOnly<House>()
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

    public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync()
    {
        return await _repository
            .AllReadOnly<Category>()
            .Select(c => new HouseCategoryServiceModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }

    public async Task<bool> CategoryExistsAsync(int categoryId)
        => await _repository.AllReadOnly<Category>().AnyAsync(c => c.Id == categoryId);

    public async Task<int> CreateAsync(HouseFormModel model, int agentId)
    {
        var house = new House()
        {
            Title = model.Title,
            Address = model.Address,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            PricePerMonth = model.PricePerMonth,
            CategoryId = model.CategoryId,
            AgentId = agentId
        };

        await _repository.AddAsync(house);
        await _repository.SaveChangesAsync();
        
        return house.Id;
    }
}