using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Areas.Admin.Controllers;

public class RentController : AdminBaseController
{
    private readonly IRentService _rentService;

    public RentController(IRentService rentService)
    {
        _rentService = rentService;
    }
    
    [Route("Rent/All")]
    public async Task<IActionResult> AllAsync()
    {
        var models = await _rentService.AllAsync();
        return View(models);
    }
}