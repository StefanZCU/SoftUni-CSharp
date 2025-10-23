using System.Security.Claims;
using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contracts.AgentServices;
using HouseRentingSystem.Core.Contracts.HouseServices;
using HouseRentingSystem.Core.Exceptions;
using HouseRentingSystem.Core.Models.HouseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;

public class HouseController : BaseController
{
    private readonly IHouseService _houseService;

    private readonly IAgentService _agentService;

    private readonly ILogger _logger;

    public HouseController(
        IHouseService houseService,
        IAgentService agentService,
        ILogger<HouseController> logger)
    {
        _houseService = houseService;
        _agentService = agentService;
        _logger = logger;
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
        if (!(await _houseService.ExistsAsync(id)))
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
        if (!(await _houseService.ExistsAsync(id)))
        {
            return BadRequest();
        }

        if (!(await _houseService.HasAgentWithIdAsync(id, User.Id())))
        {
            return Unauthorized();
        }

        var model = await _houseService.GetHouseFormModelByIdAsync(id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(HouseFormModel model, int id)
    {
        if (!(await _houseService.ExistsAsync(id)))
        {
            return BadRequest();
        }

        if (!(await _houseService.HasAgentWithIdAsync(id, User.Id())))
        {
            return Unauthorized();
        }

        if (!await _houseService.CategoryExistsAsync(model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
        }

        if (!ModelState.IsValid)
        {
            model.Categories = await _houseService.AllCategoriesAsync();
            return View(model);
        }

        await _houseService.EditAsync(id, model);

        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        if (!(await _houseService.ExistsAsync(id)))
        {
            return BadRequest();
        }
        
        if (!(await _houseService.HasAgentWithIdAsync(id, User.Id())))
        {
            return Unauthorized();
        }
        
        var house = await _houseService.HouseDetailsByIdAsync(id);

        var model = new HouseDetailsViewModel()
        {
            Address = house.Address,
            Title = house.Title,
            ImageUrl = house.ImageUrl,
            Id = id
        };
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(HouseDetailsViewModel model)
    {
        if (!(await _houseService.ExistsAsync(model.Id)))
        {
            return BadRequest();
        }
        
        if (!(await _houseService.HasAgentWithIdAsync(model.Id, User.Id())))
        {
            return Unauthorized();
        }
        
        await _houseService.DeleteAsync(model.Id);
        
        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Rent(int id)
    {
        if (!(await _houseService.ExistsAsync(id)))
        {
            return BadRequest();
        }
        
        if (await _agentService.ExistsByIdAsync(User.Id()))
        {
            return Unauthorized();
        }

        if (await _houseService.IsRentedAsync(id))
        {
            return BadRequest();
        }
        
        await _houseService.RentAsync(id, User.Id());
        
        return RedirectToAction(nameof(Mine));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        if (!(await _houseService.ExistsAsync(id)) || !(await _houseService.IsRentedAsync(id)))
        {
            return BadRequest();
        }

        try
        {
            await _houseService.LeaveAsync(id, User.Id());
        }
        catch (UnauthorizedActionException uae)
        {
            _logger.LogError(uae, "HouseService.LeaveAsync");
            return Unauthorized();
        }

        return RedirectToAction(nameof(All));
    }
}