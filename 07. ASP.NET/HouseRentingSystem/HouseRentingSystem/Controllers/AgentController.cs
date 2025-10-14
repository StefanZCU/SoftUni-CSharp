using HouseRentingSystem.Core.Contracts.AgentServices;
using HouseRentingSystem.Core.Models.AgentModels;
using Microsoft.AspNetCore.Authorization;
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
        var model = new BecomeAgentFormModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Become(BecomeAgentFormModel model)
    {
        return RedirectToAction(nameof(HouseController.All), "House");
    }
    
}