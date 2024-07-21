using System.Security.Claims;
using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;

public class HouseController : BaseController
{
    private readonly IHouseService _houseService;
    private readonly IAgentService _agentService;

    public HouseController(
        IHouseService houseService, 
        IAgentService agentService)
    {
        _houseService = houseService;
        _agentService = agentService;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> All([FromQuery]AllHousesQueryModel query)
    {
        var model = await _houseService
            .AllAsync(
                query.Category, 
                query.SearchTerm,
                query.Sorting, 
                query.CurrentPage, 
                query.HousesPerPage);

        query.TotalHousesCount = model.TotalHousesCount;
        query.Houses = model.Houses;
        query.Categories = await _houseService.AllCategoriesNamesAsync();
        
        return View(query);
    }
    
    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        var userId = User.Id();

        IEnumerable<HouseServiceModel> model;
        
        if (await _agentService.ExistsByIdAsync(userId))
        {
            var agentId = await _agentService.GetAgentIdAsync(userId) ?? 0;
            model = await _houseService.AllHousesByAgentIdAsync(agentId);
        }
        else
        {
            model = await _houseService.AllHousesByUserIdAsync(userId);
        }
        
        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        if (await _houseService.ExistsAsync(id) == false)
        {
            return BadRequest();
        }
        
        var model = await _houseService.HouseDetailsByIdAsync(id);
        return View(model);
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
            ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
        }

        if (!ModelState.IsValid)
        {
            model.Categories = await _houseService.AllCategoriesAsync();
            return View(model);
        }

        int? agentId = await _agentService.GetAgentIdAsync(User.Id());

        int newHouseId = await _houseService.CreateAsync(model, agentId ?? 0);
        
        return RedirectToAction(nameof(Details), new { id = newHouseId });

    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        if (await _houseService.ExistsAsync(id) == false)
        {
            return BadRequest();
        }

        if (await _houseService.HasAgentWIthIdAsync(id, User.Id()) == false)
        {
            return Unauthorized();
        }

        var model = await _houseService.GetHouseFromModelByIdAsync(id);
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, HouseFormModel model)
    {
        
        if (await _houseService.ExistsAsync(id) == false)
        {
            return BadRequest();
        }

        if (await _houseService.HasAgentWIthIdAsync(id, User.Id()) == false)
        {
            return Unauthorized();
        }
        
        if (await _houseService.CategoryExistsAsync(model.CategoryId) == false)
        {
            ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
        }
        
        if (!ModelState.IsValid)
        {
            model.Categories = await _houseService.AllCategoriesAsync();
            return View(model);
        }
        
        await _houseService.EditAsync(id, model);
        
        
        return RedirectToAction(nameof(Details), new {  id });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        return View(new HouseDetailsViewModel());
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(HouseDetailsViewModel house)
    {
        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Rent(int id)
    {
        return RedirectToAction(nameof(Mine));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        return RedirectToAction(nameof(Mine));
    }
}