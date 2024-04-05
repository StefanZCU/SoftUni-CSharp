using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;
using static SoftUniBazar.Data.DataConstants;

namespace SoftUniBazar.Controllers;

[Authorize]
public class AdController : Controller
{
    private readonly BazarDbContext _data;

    public AdController(BazarDbContext context)
    {
        _data = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var ads = await _data
            .Ads
            .AsNoTracking()
            .Select(a => new AdInfoViewModel()
            {
                Category = a.Category.Name,
                CreatedOn = a.CreatedOn.ToString(DateFormat),
                Description = a.Description,
                Id = a.Id,
                ImageUrl = a.ImageUrl,
                Name = a.Name,
                Owner = a.Owner.UserName,
                Price = a.Price
            })
            .ToListAsync();
        
        return View(ads);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new AdFormViewModel
        {
            Categories = await GetCategories()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AdFormViewModel model)
    {
        if (!(await GetCategories()).Any(e => e.Id == model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
        }
        
        if (!ModelState.IsValid)
        {
            model.Categories = await GetCategories();

            return View(model);
        }

        var currentUserId = GetUserId();
        
        var ad = new Ad()
        {
            CategoryId = model.CategoryId,
            CreatedOn = DateTime.Now,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            Name = model.Name,
            OwnerId = currentUserId,
            Price = model.Price
        };

        await _data.Ads.AddAsync(ad);
        await _data.SaveChangesAsync();

        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var adToEdit = await _data.Ads.FindAsync(id);

        if (adToEdit == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();
        if (currentUserId != adToEdit.OwnerId)
        {
            return Unauthorized();
        }

        var adModel = new AdFormViewModel()
        {
            Name = adToEdit.Name,
            CategoryId = adToEdit.CategoryId,
            Description = adToEdit.Description,
            ImageUrl = adToEdit.ImageUrl,
            Price = adToEdit.Price,
            Categories = await GetCategories()
        };

        return View(adModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AdFormViewModel model, int id)
    {
        var adToEdit = await _data.Ads.FindAsync(id);

        if (adToEdit == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();
        if (currentUserId != adToEdit.OwnerId)
        {
            return Unauthorized();
        }

        if (!(await GetCategories()).Any(c => c.Id != model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
        }

        adToEdit.Name = model.Name;
        adToEdit.Description = model.Description;
        adToEdit.ImageUrl = model.ImageUrl;
        adToEdit.Price = model.Price;
        adToEdit.CategoryId = model.CategoryId;

        await _data.SaveChangesAsync();
        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> Cart()
    {
        string currentUserId = GetUserId();
        
        var ads = await _data
            .AdBuyers
            .AsNoTracking()
            .Where(ab => ab.BuyerId == currentUserId)
            .Select(ab => new AdInfoViewModel()
            {
                Category = ab.Ad.Category.Name,
                CreatedOn = ab.Ad.CreatedOn.ToString(DateFormat),
                Description = ab.Ad.Description,
                Id = ab.AdId,
                ImageUrl = ab.Ad.ImageUrl,
                Name = ab.Ad.Name,
                Owner = ab.Ad.Owner.UserName,
                Price = ab.Ad.Price
            })
            .ToListAsync();
        
        return View(ads);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int id)
    {
        string currentUserId = GetUserId();

        var adToAdd = await _data.Ads.FindAsync(id);

        if (adToAdd == null)
        {
            return BadRequest();
        }

        var entry = new AdBuyer()
        {
            AdId = adToAdd.Id,
            BuyerId = currentUserId
        };

        if (await _data.AdBuyers.ContainsAsync(entry))
        {
            return RedirectToAction("All");
        }

        await _data.AdBuyers.AddAsync(entry);
        await _data.SaveChangesAsync();

        return RedirectToAction("Cart");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int id)
    {
        var currentUserId = GetUserId();

        var adToRemove = await _data.Ads.FindAsync(id);

        if (adToRemove == null)
        {
            return BadRequest();
        }

        var entryToRemove =
            await _data.AdBuyers.FirstOrDefaultAsync(ab => ab.BuyerId == currentUserId && ab.AdId == id);

        if (entryToRemove == null)
        {
            return BadRequest();
        }

        _data.AdBuyers.Remove(entryToRemove);
        await _data.SaveChangesAsync();

        return RedirectToAction("All");

    }
    

    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

    private async Task<IEnumerable<CategoryViewModel>> GetCategories()
    {
        return await _data.Categories
            .AsNoTracking()
            .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }
}