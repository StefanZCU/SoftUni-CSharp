using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Contacts.Models;
using Microsoft.AspNetCore.Authorization;

namespace Contacts.Controllers;

[Authorize]
public class HomeController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("All", "Contacts");
        }
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}