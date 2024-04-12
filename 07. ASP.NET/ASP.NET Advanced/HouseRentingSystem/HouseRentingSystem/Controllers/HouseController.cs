using System.Security.Claims;
using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        var model = new AllHousesQueryModel();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = new HouseDetailsViewModel();
        return View(model);
    }

    [HttpGet]
    [MustBeAgent]
    public async Task<IActionResult> Add()
    {
        var model = new HouseFormModel()
        {
            Categories = await _houseService.AllCategories()
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
            model.Categories = await _houseService.AllCategories();

            return View(model);
        }

        var agentId = await _agentService.GetAgentIdAsync(User.Id());

        var newHouseId = await _houseService.CreateAsync(model, agentId ?? 0);
        
        return RedirectToAction(nameof(Details), new { id = newHouseId });
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var model = new HouseFormModel();
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, HouseFormModel model)
    {
        return RedirectToAction(nameof(Details), new { id = 1});
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var model = new HouseDetailsViewModel();
        return View(model);
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