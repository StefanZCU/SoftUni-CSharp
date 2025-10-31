using HouseRentingSystem.Core.Contracts.UserServices;
using HouseRentingSystem.Core.Models.AdminModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static HouseRentingSystem.Core.Constants.AdministratorConstants;

namespace HouseRentingSystem.Areas.Admin.Controllers;

public class UserController : AdminBaseController
{
    private readonly IUserService _userService;
    private readonly IMemoryCache _memoryCache;

    public UserController(
        IUserService userService,
        IMemoryCache memoryCache)
    {
        _userService = userService;
        _memoryCache = memoryCache;
    }

    [Route("User/All")]
    public async Task<IActionResult> AllAsync()
    {
        var models = _memoryCache.Get<IEnumerable<UserServiceModel>>(UsersCacheKey);

        if (models == null || !models.Any())
        {
            models = await _userService.AllAsync();
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            
            _memoryCache.Set(UsersCacheKey, models, cacheOptions);
        }

        return View(models);
    }
}