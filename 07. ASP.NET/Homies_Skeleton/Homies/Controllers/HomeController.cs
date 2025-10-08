using Homies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homies.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity is { IsAuthenticated: true })
            {
                return RedirectToAction("All", "Event");
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