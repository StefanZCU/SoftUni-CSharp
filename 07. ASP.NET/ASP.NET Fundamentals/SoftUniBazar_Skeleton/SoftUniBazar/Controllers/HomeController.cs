using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity is { IsAuthenticated: true})
            {
                return RedirectToAction("All", "Ad");
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}