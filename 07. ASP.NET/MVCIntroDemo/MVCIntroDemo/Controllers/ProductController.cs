using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemo.Models;

namespace MVCIntroDemo.Controllers;

public class ProductController : Controller
{

    private readonly IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
    {
        new ProductViewModel()
        {
            Id = 1,
            Name = "Cheese",
            Price = 7
        },
        new ProductViewModel()
        {
            Id = 2,
            Name = "Ham",
            Price = 8
        },
        new ProductViewModel()
        {
            Id = 3,
            Name = "Pepperoni",
            Price = 10
        }
    };
    
    public IActionResult Index()
    {
        return View(_products);
    }
    
    public IActionResult ById(int id)
    {
        if (id <= 0 || id > _products.Count())
        {
            TempData["Error"] = "There is no such product";
            return RedirectToAction(nameof(Index));
        }
        
        return View(_products.FirstOrDefault(p => p.Id == id));
    }

    public IActionResult AllAsJson()
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };
        
        return Json(_products, options);
    }

    public IActionResult AsPlainText()
    {
        return Content(GetAllProductsAsString());
    }

    public IActionResult DownloadAll()
    {

        string content = GetAllProductsAsString();
        
        Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment; filename=products.txt");
        
        return File(Encoding.UTF8.GetBytes(content), "text/plain");
    }

    public IActionResult Filtered(string? keyword)
    {
        if (keyword == null)
        {
            return RedirectToAction(nameof(Index));
        }
        
        var model = _products
            .Where(p => p.Name.ToLower().Contains(keyword.ToLower()));
        
        return View(nameof(Index), model);
    }

    private string GetAllProductsAsString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var product in _products)
        {
            sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.");
        }
        
        return sb.ToString();
    }
}