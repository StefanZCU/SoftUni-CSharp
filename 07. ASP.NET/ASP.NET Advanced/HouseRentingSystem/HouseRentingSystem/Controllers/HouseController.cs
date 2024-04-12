using System.Security.Claims;
using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static HouseRentingSystem.Core.Constants.MessageConstants;


namespace HouseRentingSystem.Controllers;


public class HouseController : BaseController
{
    private readonly IHouseService _houseService;
    private readonly IAgentService _agentService;

    public HouseController(IHouseService houseService, IAgentService agentService)
    {
        _houseService = houseService;
        _agentService = agentService;
    }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> All([FromQuery] AllHousesQueryModel query)
    {
        var queryResult = await _houseService.AllAsync(
            query.Category,
            query.SearchTerm,
            query.Sorting,
            query.CurrentPage,
            AllHousesQueryModel.HousesPerPage);

        query.TotalHousesCount = queryResult.TotalHousesCount;
        query.Houses = queryResult.Houses;

        var houseCategories = await _houseService.AllCategoriesNamesAsync();
        query.Categories = houseCategories;

        return View(query);
    }

    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        IEnumerable<HouseServiceModel> myHouses;
        var userId = User.Id();

        if (await _agentService.ExistByIdAsync(userId))
        {
            var currentAgentId = await _agentService.GetAgentIdAsync(userId) ?? 0;
            myHouses = await _houseService.AllHousesByAgentIdAsync(currentAgentId);
        }
        else
        {
            myHouses = await _houseService.AllHousesByUserIdAsync(userId);
        }
        
        return View(myHouses);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        if (await _houseService.ExistsAsync(id) == false)
        {
            return BadRequest();
        }

        var houseModel = await _houseService.HouseDetailsByIdAsync(id);
        
        return View(houseModel);
    }

    [HttpGet]
    [MustBeAgent]
    public async Task<IActionResult> Add()
    {
        var model = new HouseFormModel()
        {
            Categories = await _houseService.AllCategoriesAsync()
        };
        
        return View(model);
    }

    [HttpPost]
    [MustBeAgent]
    public async Task<IActionResult> Add(HouseFormModel model)
    {
        if (await _houseService.CategoryExistsAsync(model.CategoryId) == false)
        {
            ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesNotExist);
        }

        if (!ModelState.IsValid)
        {
            model.Categories = await _houseService.AllCategoriesAsync();

            return View(model);
        }

        int? agentId = await _agentService.GetAgentIdAsync(User.Id());

        var newHouseId = await _houseService.CreateAsync(model, agentId ?? 0);
        
        return RedirectToAction(nameof(Details), new { id = newHouseId });
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (await _houseService.ExistsAsync(id) == false)
        {
            return BadRequest();
        }

        if (await _houseService.HasAgentWithIdAsync(id, User.Id()) == false)
        {
            return Unauthorized();
        }

        var houseModel = await _houseService.GetHouseFormModelByIdAsync(id);
        
        return View(houseModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, HouseFormModel model)
    {
        if (await _houseService.ExistsAsync(id) == false)
        {
            return BadRequest();
        }

        if (await _houseService.HasAgentWithIdAsync(id, User.Id()) == false)
        {
            return Unauthorized();
        }

        if (await _houseService.CategoryExistsAsync(model.CategoryId) == false)
        {
            ModelState.AddModelError(nameof(model.CategoryId),"Category does not exist.");
        }

        if (!ModelState.IsValid)
        {
            model.Categories = await _houseService.AllCategoriesAsync();

            return View(model);
        }
        
        await _houseService.EditAsync(model, id);
        
        return RedirectToAction(nameof(Details), new { id = id });
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        if (await _houseService.ExistsAsync(id) == false)
        {
            return BadRequest();
        }

        if (await _houseService.HasAgentWithIdAsync(id, User.Id()) == false)
        {
            return Unauthorized();
        }
        
        var house = await _houseService.HouseDetailsByIdAsync(id);

        var model = new HouseDetailsViewModel()
        {
            Title = house.Title,
            ImageUrl = house.ImageUrl,
            Address = house.Address
        };
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(HouseDetailsViewModel house)
    {
        if (await _houseService.ExistsAsync(house.Id) == false)
        {
            return BadRequest();
        }

        if (await _houseService.HasAgentWithIdAsync(house.Id, User.Id()) == false)
        {
            return Unauthorized();
        }

        await _houseService.DeleteAsync(house.Id);
        
        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Rent(int id)
    {
        if (await _houseService.ExistsAsync(id) == false)
        {
            return BadRequest();
        }

        if (await _agentService.ExistByIdAsync(User.Id()))
        {
            return Unauthorized();
        }

        if (await _houseService.IsRentedAsync(id))
        {
            return BadRequest();
        }

        await _houseService.RentAsync(id, User.Id());
        
        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        if (await _houseService.ExistsAsync(id) == false || await _houseService.IsRentedAsync(id) == false)
        {
            return BadRequest();
        }

        if (await _houseService.IsRentedByUserWithIdAsync(id, User.Id()) == false) 
        {
            return Unauthorized();
        }

        await _houseService.LeaveAsync(id);
        
        return RedirectToAction(nameof(Mine));
    }
}