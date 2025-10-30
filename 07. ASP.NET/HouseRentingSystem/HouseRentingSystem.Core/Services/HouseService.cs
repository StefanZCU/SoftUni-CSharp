using HouseRentingSystem.Core.Contracts.HouseServices;
using HouseRentingSystem.Core.Enumerators;
using HouseRentingSystem.Core.Exceptions;
using HouseRentingSystem.Core.Models.AgentModels;
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
            .Where(h => h.IsApproved)
            .OrderByDescending(h => h.Id)
            .Take(3)
            .Select(h => new HouseIndexServiceModel()
            {
                Id = h.Id,
                Title = h.Title,
                ImageUrl = h.ImageUrl,
                Address = h.Address
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

    public async Task<HouseQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null,
        HouseSorting sorting = HouseSorting.Newest,
        int currentPage = 1, int housesPerPage = 1)
    {
        var housesToShow = _repository
            .AllReadOnly<House>()
            .Where(h => h.IsApproved);

        if (!string.IsNullOrWhiteSpace(category))
        {
            housesToShow = housesToShow
                .Where(h => h.Category.Name == category);
        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var normalizedSearchTerm = searchTerm.ToLower();
            housesToShow = housesToShow
                .Where(h =>
                    h.Title.ToLower().Contains(normalizedSearchTerm) ||
                    h.Address.ToLower().Contains(normalizedSearchTerm) ||
                    h.Description.ToLower().Contains(normalizedSearchTerm));
        }

        housesToShow = sorting switch
        {
            HouseSorting.Price => housesToShow
                .OrderBy(h => h.PricePerMonth),

            HouseSorting.NotRentedFirst => housesToShow
                .OrderBy(h => h.RenterId != null)
                .ThenBy(h => h.Id),

            _ => housesToShow
                .OrderByDescending(h => h.Id)
        };

        var houses = await housesToShow
            .Skip((currentPage - 1) * housesPerPage)
            .Take(housesPerPage)
            .ProjectToHouseServiceModel()
            .ToListAsync();

        var totalHouses = await housesToShow.CountAsync();

        return new HouseQueryServiceModel()
        {
            TotalHousesCount = totalHouses,
            Houses = houses
        };
    }

    public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
    {
        return await _repository
            .AllReadOnly<Category>()
            .Select(c => c.Name)
            .Distinct()
            .ToListAsync();
    }

    public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId)
    {
        return await _repository
            .AllReadOnly<House>()
            .Where(h => h.IsApproved)
            .Where(h => h.AgentId == agentId)
            .ProjectToHouseServiceModel()
            .ToListAsync();
    }

    public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId)
    {
        return await _repository
            .AllReadOnly<House>()
            .Where(h => h.IsApproved)
            .Where(h => h.RenterId == userId)
            .ProjectToHouseServiceModel()
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(int id)
        => await _repository.AllReadOnly<House>().AnyAsync(h => h.Id == id);

    public async Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id)
    {
        return await _repository
            .AllReadOnly<House>()
            .Where(h => h.IsApproved)
            .Where(h => h.Id == id)
            .Select(h => new HouseDetailsServiceModel()
            {
                Id = h.Id,
                Address = h.Address,
                Agent = new AgentServiceModel()
                {
                    FullName = $"{h.Agent.User.FirstName} {h.Agent.User.LastName}",
                    Email = h.Agent.User.Email,
                    PhoneNumber = h.Agent.PhoneNumber
                },
                Category = h.Category.Name,
                Description = h.Description,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                Title = h.Title,
                IsRented = h.RenterId != null
            })
            .FirstAsync();
    }

    public async Task EditAsync(int houseId, HouseFormModel model)
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
        var house = await _repository
            .AllReadOnly<House>()
            .Where(h => h.IsApproved)
            .Where(h => h.Id == id)
            .Select(h => new HouseFormModel()
            {
                Address = h.Address,
                CategoryId = h.CategoryId,
                Description = h.Description,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                Title = h.Title
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

    public async Task<bool> IsRentedAsync(int houseId)
    {
        var result = false;

        var house = await _repository.GetByIdAsync<House>(houseId);

        if (house != null)
        {
            result = house.RenterId != null;
        }

        return result;
    }

    public async Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId)
    {
        var result = false;

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

    public async Task LeaveAsync(int houseId, string userId)
    {
        var house = await _repository.GetByIdAsync<House>(houseId);

        if (house != null)
        {
            if (house.RenterId != userId)
            {
                throw new UnauthorizedActionException("The user is not renting this house.");
            }
            
            house.RenterId = null;
            await _repository.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<HouseServiceModel>> GetUnapprovedHousesAsync()
    {
        return await _repository
            .AllReadOnly<House>()
            .Where(h => h.IsApproved == false)
            .ProjectToHouseServiceModel()
            .ToListAsync();
    }

    public async Task ApproveHouseAsync(int houseId)
    {
        var house = await _repository.GetByIdAsync<House>(houseId);

        if (house is { IsApproved: false })
        {
            house.IsApproved = true;
            await _repository.SaveChangesAsync();
        }
    }
}