using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Contracts;
using ShoppingListApp.Models;

namespace ShoppingListApp.Controllers;

public class ProductController : Controller
{
    private readonly IProductService  _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await _productService.GetAllAsync();
        
        return View(model);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var model = new ProductViewModel();
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _productService.AddProductAsync(model);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var model = await _productService.GetByIdAsync(id);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductViewModel model, int id)
    {
        if (!ModelState.IsValid || model.Id != id)
        {
            return View(model);
        }
        
        await _productService.UpdateProductAsync(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteProductAsync(id);
        return RedirectToAction(nameof(Index));
    }
}