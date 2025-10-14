using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreAdvancedDemo.Models;
using Microsoft.Extensions.FileProviders;

namespace AspNetCoreAdvancedDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult GetPrice(decimal price)
    {
        return Ok(new { price });
    }

    [HttpGet]
    public async Task<IActionResult> UploadFiles() => View();
    
    
    [HttpPost]
    public async Task<IActionResult> UploadFiles(IEnumerable<IFormFile> files)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Files");

        foreach (var file in files.Where(f => f.Length > 0))
        {
            string fileName = Path.Combine(path, file.FileName);

            await using var fileStream = new FileStream(fileName, FileMode.Create);
            await file.CopyToAsync(fileStream);
        }

        return Ok(new
        {
            savedFilesLength = files.Sum(f => f.Length)
        });
    }

    public IActionResult Download(string fileName)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Files");
        
        IFileProvider fileProvider = new PhysicalFileProvider(path);
        IFileInfo fileInfo = fileProvider.GetFileInfo(fileName);
        
        var stream = fileInfo.CreateReadStream();
        var mimeType = "application/octet-stream";
        
        return File(stream, mimeType, fileName);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}