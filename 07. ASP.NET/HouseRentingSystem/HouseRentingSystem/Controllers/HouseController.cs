using System.Security.Claims;
using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contracts.AgentServices;
using HouseRentingSystem.Core.Contracts.HouseServices;
using HouseRentingSystem.Core.Models.HouseModels;
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
    public async Task<IActionResult> All([FromQuery] AllHousesQueryModel query)
    {
        var model = await _houseService.AllAsync(
            query.Category,
            query.SearchTerm,
            query.Sorting,
            query.CurrentPage,
            AllHousesQueryModel.HousesPerPage);

        query.TotalHousesCount = model.TotalHousesCount;
        query.Houses = model.Houses;

        query.Categories = await _houseService.AllCategoriesNamesAsync();

        return View(query);
    }

    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        var userId = User.Id();

        IEnumerable<HouseServiceModel> myHouses;

        if (await _agentService.ExistsByIdAsync(userId))
        {
            var agentId = await _agentService.GetAgentIdAsync(userId) ?? 0;
            myHouses = await _houseService.AllHousesByAgentIdAsync(agentId);
        }
        else
        {
            myHouses = await _houseService.AllHousesByUserIdAsync(userId);
        }

        return View(myHouses);
    }

    public async Task<IActionResult> Details(int id)
    {
        var model = new HouseDetailsViewModel();
        return View(model);
    }

    [HttpGet]
    [MustBeAgent]
    public async Task<IActionResult> Add()
    {
        return View(new HouseFormModel()
        {
            Categories = await _houseService.AllCategoriesAsync()
        });
    }

    [HttpPost]
    [MustBeAgent]
    public async Task<IActionResult> Add(HouseFormModel model)
    {
        if (!await _houseService.CategoryExistsAsync(model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
        }

        if (!ModelState.IsValid)
        {
            model.Categories = await _houseService.AllCategoriesAsync();

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
    public async Task<IActionResult> Edit(HouseFormModel model, int id)
    {
        return RedirectToAction(nameof(Details), new { id = "1" });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var model = new HouseDetailsViewModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(HouseDetailsViewModel model)
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