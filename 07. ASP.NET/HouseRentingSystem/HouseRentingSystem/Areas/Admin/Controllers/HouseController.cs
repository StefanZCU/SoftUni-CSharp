using System.Security.Claims;
using HouseRentingSystem.Core.Contracts.AgentServices;
using HouseRentingSystem.Core.Contracts.HouseServices;
using HouseRentingSystem.Core.Models.AdminModels;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Areas.Admin.Controllers;

public class HouseController : AdminBaseController
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

    public async Task<IActionResult> Mine()
    {
        var adminUserId = User.Id();
        int adminAgentId = await _agentService.GetAgentIdAsync(adminUserId) ?? 0;

        var myHouses = new MyHousesViewModel()
        {
            AddedHouses = await _houseService.AllHousesByAgentIdAsync(adminAgentId),
            RentedHouses = await _houseService.AllHousesByUserIdAsync(adminUserId)
        };
        
        return View(myHouses);
    }
}