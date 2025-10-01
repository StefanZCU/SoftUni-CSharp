using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TextSplitterApp.Models;

namespace TextSplitterApp.Controllers;

public class HomeController : Controller
{

    public IActionResult Index(TextViewModel model) => View(model);

    [HttpPost]
    public IActionResult Split(TextViewModel model)
    {
        var splitTextArray = model
            .Text
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        
        model.SplitText = string.Join(Environment.NewLine, splitTextArray);

        return RedirectToAction(nameof(Index), model);
    }
    
}