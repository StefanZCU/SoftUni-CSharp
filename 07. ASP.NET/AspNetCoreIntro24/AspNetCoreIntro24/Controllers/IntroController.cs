using AspNetCoreIntro24.Contracts;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIntro24.Models;

namespace AspNetCoreIntro24.Controllers;

public class IntroController : Controller
{
    private readonly IStudentService _studentService;

    public IntroController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetNumber(int number)
    {
        ViewData["Title"] = "GetNumber";
        
        return View(number);
    }

    public IActionResult GetStudentData(int id)
    {
        ViewData["Title"] = "GetStudentData";

        Student model = _studentService.GetStudent(id);
        
        return View("StudentData", model);
    }

    public IActionResult EditStudent(Student model)
    {
        if (!ModelState.IsValid)
        {
            return View("StudentData", model);
        }

        if (_studentService.UpdateStudent(model))
        {
            return RedirectToAction(nameof(GetStudentData), new { id = model.Id });
        }
        
        return RedirectToAction(nameof(Index));
    }
}