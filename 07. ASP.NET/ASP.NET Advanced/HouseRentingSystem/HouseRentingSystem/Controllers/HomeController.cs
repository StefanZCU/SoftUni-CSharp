using System.Diagnostics;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Models;

namespace HouseRentingSystem.Controllers;

public class HomeController : Controller
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

    public async Task<IActionResult> Index()
    {
        var houses = await _houseService.LastThreeHouses();
        
        return View(houses);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}