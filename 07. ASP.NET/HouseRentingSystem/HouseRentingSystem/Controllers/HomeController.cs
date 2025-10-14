using System.Diagnostics;
using HouseRentingSystem.Core.Contracts.HouseServices;
using HouseRentingSystem.Core.Models.HomeModels;
using HouseRentingSystem.Core.Models.HouseModels;
using HouseRentingSystem.Core.Services.HouseServices;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Models;

namespace HouseRentingSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHouseService _houseService;

    public HomeController(
        ILogger<HomeController> logger,
        IHouseService houseService)
    {
        _logger = logger;
        _houseService = houseService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _houseService.LastThreeHouses();
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}