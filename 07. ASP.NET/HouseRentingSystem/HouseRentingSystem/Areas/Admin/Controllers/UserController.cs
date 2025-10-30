using HouseRentingSystem.Core.Contracts.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Areas.Admin.Controllers;

public class UserController : AdminBaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Route("User/All")]
    public async Task<IActionResult> AllAsync()
    {
        var models = await _userService.AllAsync();
        return View(models);
    }
}