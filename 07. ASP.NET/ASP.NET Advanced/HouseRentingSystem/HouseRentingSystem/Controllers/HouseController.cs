using HouseRentingSystem.Core.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;

public class HouseController : BaseController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var model = new AllHousesQueryModel();
        return View(model);
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
    public async Task<IActionResult> Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(HouseFormModel model)
    {
        return RedirectToAction(nameof(Details), new { id = 1 });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        return View(new HouseFormModel());
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, HouseFormModel model)
    {
        return RedirectToAction(nameof(Details), new { id = id });
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