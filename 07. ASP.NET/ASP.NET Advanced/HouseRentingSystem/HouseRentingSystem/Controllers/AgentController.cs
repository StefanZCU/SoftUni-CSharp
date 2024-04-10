using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Agent;
using HouseRentingSystem.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;

public class AgentController : BaseController
{
    private readonly IAgentService _agentService;

    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }
        
    [HttpGet]
    public async Task<IActionResult> Become()
    {
        if (await _agentService.ExistByIdAsync(User.Id()))
        {
            return BadRequest();
        }
        
        
        
        var model = new BecomeAgentFormModel();
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Become(BecomeAgentFormModel agent)
    {
        return RedirectToAction(nameof(HouseController.All), "House");
    }
    
}