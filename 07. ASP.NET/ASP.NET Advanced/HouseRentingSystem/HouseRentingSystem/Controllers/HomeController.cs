using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HouseRentingSystem.Controllers;

public class HomeController : BaseController
{
    private readonly IHouseService _houseService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(
        ILogger<HomeController> logger,
        IHouseService houseService)
    {
        _houseService = houseService;
        _logger = logger;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var houses = await _houseService.LastThreeHousesAsync();
        
        return View(houses);
    }

    [AllowAnonymous]
    public IActionResult Error(int statusCode)
    {
        return statusCode switch
        {
            400 => View("Error400"),
            401 => View("Error401"),
            _ => View("Error")
        };
    }
}