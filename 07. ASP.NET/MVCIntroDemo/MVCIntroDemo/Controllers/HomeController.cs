using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCIntroDemo.Models;

namespace MVCIntroDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Index page loaded.");
        
        ViewData["Message"] = "Welcome to the MVC Intro Demo";
        
         return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
         ViewData["Message"] = "This is an ASP.NET MVC application.";
         
         return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}