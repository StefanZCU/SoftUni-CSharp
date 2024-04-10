using System.Diagnostics;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Mvc;
using HouseRentingSystem.Models;
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
        var houses = await _houseService.LastThreeHouses();
        
        return View(houses);
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}