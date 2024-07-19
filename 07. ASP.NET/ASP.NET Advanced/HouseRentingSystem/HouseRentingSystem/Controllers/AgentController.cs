using System.Security.Claims;
using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Agent;
using Microsoft.AspNetCore.Mvc;
using static HouseRentingSystem.Core.Constants.MessageConstants;

namespace HouseRentingSystem.Controllers;

public class AgentController : BaseController
{
    private readonly IAgentService _agentService;

    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }
    
    [HttpGet]
    [NotAnAgent]
    public IActionResult Become()
    {
        var model = new BecomeAgentFormModel();
        return View(model);
    }

    [HttpPost]
    [NotAnAgent]
    public async Task<IActionResult> Become(BecomeAgentFormModel model)
    {
        if (await _agentService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
        {
            ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
        }

        if (await _agentService.UserHasRentsAsync(User.Id()))
        {
            ModelState.AddModelError("", HasRents);
        }
        
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _agentService.CreateAsync(User.Id(), model.PhoneNumber);
        
        return RedirectToAction(nameof(HouseController.All), "House");
    }
} 