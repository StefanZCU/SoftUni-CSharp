using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}