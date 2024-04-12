using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Enumerations;
using HouseRentingSystem.Core.Models.Agent;
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
                Title = h.Title,
                ImageUrl = h.ImageUrl
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategoriesAsync()
    {
        return await
            _repository
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
        return await _repository.AllReadOnly<Category>().AnyAsync(c => c.Id == categoryId);
    }

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

    public async Task<HouseQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest,
        int currentPage = 1, int housePerPage = 1)
    {
        var housesQuery = _repository.AllReadOnly<House>();

        if (!string.IsNullOrWhiteSpace(category))
        {
            housesQuery = housesQuery.Where(h => h.Category.Name == category);
        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            string normalizedSearchTerm = searchTerm.ToLower();
            
            housesQuery = housesQuery
                .Where(h =>
                    h.Title.ToLower().Contains(normalizedSearchTerm) ||
                    h.Description.ToLower().Contains(normalizedSearchTerm) ||
                    h.Address.ToLower().Contains(normalizedSearchTerm));
        }
        
        housesQuery = sorting switch
        {
            HouseSorting.Price => housesQuery.OrderBy(h => h.PricePerMonth),
            HouseSorting.NotRentedFirst => housesQuery.OrderBy(h => h.RenterId == null)
                .ThenByDescending(h => h.Id),
            _ => housesQuery.OrderByDescending(h => h.Id)
        };


        var houses = await housesQuery
            .Skip((currentPage - 1) * housePerPage)
            .Take(housePerPage)
            .ProjectToHouseServiceModel()
            .ToListAsync();

        var totalHouses = await housesQuery.CountAsync();

        return new HouseQueryServiceModel()
        {
            TotalHousesCount = totalHouses,
            Houses = houses
        };
    }

    public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
    {
        return await _repository.AllReadOnly<Category>()
            .Select(c => c.Name)
            .Distinct()
            .ToListAsync();
    }

    public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId)
    {
        return await _repository
            .AllReadOnly<House>()
            .Where(h => h.AgentId == agentId)
            .ProjectToHouseServiceModel()
            .ToListAsync();
    }

    public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId)
    {
        return await _repository
            .AllReadOnly<House>()
            .Where(h => h.RenterId == userId)
            .ProjectToHouseServiceModel()
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _repository
            .AllReadOnly<House>()
            .AnyAsync(h => h.Id == id);
    }

    public async Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id)
    {
        return await _repository
            .AllReadOnly<House>()
            .Where(h => h.Id == id)
            .Select(h => new HouseDetailsServiceModel()
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                Description = h.Description,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                IsRented = h.RenterId != null,
                Category = h.Category.Name,
                Agent = new AgentServiceModel()
                {
                    PhoneNumber = h.Agent.PhoneNumber,
                    Email = h.Agent.User.Email
                }
            })
            .FirstAsync();
    }

    public async Task EditAsync(HouseFormModel model, int houseId)
    {
        var house = await _repository.GetByIdAsync<House>(houseId);

        if (house != null)
        {
            house.Title = model.Title;
            house.Address = model.Address;
            house.Description = model.Description;
            house.ImageUrl = model.ImageUrl;
            house.PricePerMonth = model.PricePerMonth;
            house.CategoryId = model.CategoryId;
            
            await _repository.SaveChangesAsync();
        }
    }

    public async Task<bool> HasAgentWithIdAsync(int houseId, string currentUserId)
    {
        return await _repository
            .AllReadOnly<House>()
            .AnyAsync(h => h.Id == houseId && h.Agent.UserId == currentUserId);
    }

    public async Task<HouseFormModel?> GetHouseFormModelByIdAsync(int id)
    {
        var house =  await _repository.AllReadOnly<House>()
            .Where(h => h.Id == id)
            .Select(h => new HouseFormModel()
            {
                Title = h.Title,
                Address = h.Address,
                Description = h.Description,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                CategoryId = h.CategoryId
            })
            .FirstOrDefaultAsync();

        if (house != null)
        {
            house.Categories = await AllCategoriesAsync();
        }
        
        return house;
    }

    public async Task DeleteAsync(int houseId)
    {
        await _repository.DeleteAsync<House>(houseId);
        await _repository.SaveChangesAsync();
    }

    public async Task<bool> IsRentedAsync(int id)
    {
        bool result = false;

        var house = await _repository.GetByIdAsync<House>(id);

        if (house != null)
        {
            result = house.RenterId != null;
        }
        
        return result;
    }

    public async Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId)
    {
        bool result = false;

        var house = await _repository.GetByIdAsync<House>(houseId);

        if (house != null)
        {
            result = house.RenterId == userId;
        }
        
        return result;
    }

    public async Task RentAsync(int houseId, string userId)
    {
        var house = await _repository.GetByIdAsync<House>(houseId);

        if (house != null)
        {
            house.RenterId = userId;
            await _repository.SaveChangesAsync();
        }
    }

    public async Task LeaveAsync(int houseId)
    {
        var house = await _repository.GetByIdAsync<House>(houseId);

        if (house != null)
        {
            house.RenterId = null;
            _repository.SaveChangesAsync();
        }
    }
}