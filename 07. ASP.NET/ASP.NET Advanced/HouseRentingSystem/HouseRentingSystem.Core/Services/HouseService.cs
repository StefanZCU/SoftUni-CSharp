using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Enums;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services;

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
                ImageUrl = h.ImageUrl,
                Title = h.Title
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
    {
        return await _repository.AllReadOnly<Category>()
            .AnyAsync(c => c.Id == categoryId);
    }

    public async Task<int> CreateAsync(HouseFormModel model, int agentId)
    {
        var house = new House()
        {
            Address = model.Address,
            AgentId = agentId,
            CategoryId = model.CategoryId,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            PricePerMonth = model.PricePerMonth,
            Title = model.Title
        };

        await _repository.AddAsync(house);
        await _repository.SaveChangesAsync();
        
        return house.Id;
    }

    public async Task<HouseQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null,
        HouseSorting sorting = HouseSorting.Newest,
        int currentPage = 1, int housesPerPage = 1)
    {
        var housesToShow = _repository.AllReadOnly<House>();

        if (category != null)
        {
            housesToShow = housesToShow.Where(h => h.Category.Name == category);
        }

        if (searchTerm != null)
        {
            string normalizedSearchTerm = searchTerm.ToLower();
            housesToShow = housesToShow.Where(h => h.Title.ToLower().Contains(normalizedSearchTerm) ||
                                                   h.Address.ToLower().Contains(normalizedSearchTerm) ||
                                                   h.Description.ToLower().Contains(normalizedSearchTerm));
        }

        housesToShow = sorting switch
        {
            HouseSorting.Price => housesToShow.OrderBy(h => h.PricePerMonth),
            HouseSorting.NotRentedFirst => housesToShow.OrderBy(h => h.RenterId != null)
                .ThenByDescending(h => h.Id),
            _ => housesToShow.OrderByDescending(h => h.Id)
        };

        var houses = await housesToShow
            .Skip((currentPage - 1) * housesPerPage)
            .Take(housesPerPage)
            .Select(h => new HouseServiceModel()
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                IsRented = !string.IsNullOrEmpty(h.RenterId)
            })
            .ToListAsync();

        int totalHouses = await housesToShow.CountAsync();

        return new HouseQueryServiceModel()
        {
            Houses = houses,
            TotalHousesCount = totalHouses
        };
    }

    public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
    {
        return await _repository.AllReadOnly<Category>()
            .Select(c => c.Name)
            .Distinct()
            .ToListAsync();
    }
}