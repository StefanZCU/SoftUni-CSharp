using Microsoft.AspNetCore.Mvc;

namespace MVCIntroDemo.Controllers;

public class NumbersController : Controller
{
    
    private readonly ILogger<NumbersController> _logger;

    public NumbersController(ILogger<NumbersController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View(50);
    }
    
    [HttpGet]
    public IActionResult Limit(int num)
    {
        return View("Index", num);
    }
}