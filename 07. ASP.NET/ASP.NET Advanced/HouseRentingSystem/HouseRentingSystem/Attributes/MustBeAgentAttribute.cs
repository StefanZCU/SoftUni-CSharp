using System.Security.Claims;
using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HouseRentingSystem.Attributes;

public class MustBeAgentAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        IAgentService? agentService = context.HttpContext.RequestServices.GetService<IAgentService>();

        if (agentService == null)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        if (agentService != null && agentService.ExistByIdAsync(context.HttpContext.User.Id()).Result == false)
        {
            context.Result = new RedirectToActionResult("Become", "Agent", null);
        }
    }
}