using System.Globalization;
using System.Security.Claims;
using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models.GameViewModels;
using GameZone.Models.GenreViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static GameZone.Common.Constants.DataConstants;
using static GameZone.Common.Constants.ErrorConstants;


namespace GameZone.Controllers;

[Authorize]
public class GameController : Controller
{
    private readonly GameZoneDbContext _context;

    public GameController(GameZoneDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new GameFormViewModel()
        {
            Genres = await GetGenresAsync()
        };
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(GameFormViewModel model)
    {

        if (!DateTime.TryParseExact(
                model.ReleasedOn,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var releasedOn))
        {
            ModelState.AddModelError(nameof(model.ReleasedOn), InvalidDateFormatError);
        }

        if ((await GetGenresAsync()).All(x => x.Id != model.GenreId))
        {
            ModelState.AddModelError(nameof(model.GenreId), GenreDoesNotExistError);
        }

        if (!ModelState.IsValid)
        {
            model.Genres = await GetGenresAsync();
            return View(model);
        }

        var gameToAdd = new Game()
        {
            Title = model.Title,
            ImageUrl = model.ImageUrl,
            Description = model.Description,
            ReleasedOn = releasedOn,
            GenreId = model.GenreId,
            PublisherId = GetUserId()
        };
        
        await _context.Games.AddAsync(gameToAdd);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var model = await _context.Games
            .AsNoTracking()
            .Select(g => new GameViewModel()
            {
                Id = g.Id,
                Title = g.Title,
                ImageUrl = g.ImageUrl,
                Genre = g.Genre.Name,
                Publisher = g.Publisher.UserName,
                ReleasedOn = g.ReleasedOn.ToString(DateFormat)
            })
            .ToListAsync();
        
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> MyZone()
    {
        var currentUserId = GetUserId();
        
        var model = await _context.GamersGames
            .AsNoTracking()
            .Where(gg => gg.GamerId == currentUserId)
            .Select(gg => new GameViewModel()
            {
                Id = gg.Game.Id,
                Title = gg.Game.Title,
                ImageUrl = gg.Game.ImageUrl,
                Genre = gg.Game.Genre.Name,
                Publisher = gg.Game.Publisher.UserName,
                ReleasedOn = gg.Game.ReleasedOn.ToString(DateFormat)
            })
            .ToListAsync();
        
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> AddToMyZone(int id)
    {
        var game = await  _context.Games.FindAsync(id);
        
        var currentUserId = GetUserId();

        if (game == null)
        {
            return NotFound();
        }

        if (_context.GamersGames.Any(gg => gg.GameId == id && gg.GamerId == currentUserId))
        {
            return RedirectToAction(nameof(All));
        }
        
        var gamersGame = new GamerGame()
        {
            GameId = id,
            GamerId = currentUserId,
        };

        if (await _context.GamersGames.ContainsAsync(gamersGame))
        {
            return RedirectToAction(nameof(All));
        }
        
        await _context.GamersGames.AddAsync(gamersGame);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(MyZone));
    }

    [HttpGet]
    public async Task<IActionResult> StrikeOut(int id)
    {
        var currentUserId = GetUserId();

        var gamersGame = await _context.GamersGames.FirstOrDefaultAsync(gg => gg.GameId == id && gg.GamerId == currentUserId);
        
        if (gamersGame == null) return NotFound();
        
        _context.GamersGames.Remove(gamersGame);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(MyZone));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var currentUserId = GetUserId();
        var gameToEdit = await _context.Games.FindAsync(id);

        if (gameToEdit == null)
        {
            return NotFound();
        }

        if (gameToEdit.PublisherId != currentUserId)
        {
            return Unauthorized();
        }

        var model = new GameFormViewModel()
        {
            Genres = await GetGenresAsync(),
            Description = gameToEdit.Description,
            ReleasedOn = gameToEdit.ReleasedOn.ToString(DateFormat),
            GenreId = gameToEdit.GenreId,
            ImageUrl = gameToEdit.ImageUrl,
            Title = gameToEdit.Title
        };
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(GameFormViewModel model, int id)
    {
        var currentUserId = GetUserId();
        var gameToEdit = await _context.Games.FindAsync(id);

        if (gameToEdit == null)
        {
            return NotFound();
        }

        if (gameToEdit.PublisherId != currentUserId)
        {
            return Unauthorized();
        }
        
        if (!DateTime.TryParseExact(
                model.ReleasedOn,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var releasedOn))
        {
            ModelState.AddModelError(nameof(model.ReleasedOn), InvalidDateFormatError);
        }

        if ((await GetGenresAsync()).All(x => x.Id != model.GenreId))
        {
            ModelState.AddModelError(nameof(model.GenreId), GenreDoesNotExistError);
        }

        if (!ModelState.IsValid)
        {
            model.Genres = await GetGenresAsync();
            return View(model);
        }
        
        gameToEdit.Title = model.Title;
        gameToEdit.ImageUrl = model.ImageUrl;
        gameToEdit.Description = model.Description;
        gameToEdit.ReleasedOn = releasedOn;
        gameToEdit.GenreId = model.GenreId;
        
        
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = await _context.Games
            .AsNoTracking()
            .Where(gg => gg.Id == id)
            .Select(g => new GameDetailsViewModel()
            {
                Id = g.Id,
                Title = g.Title,
                ImageUrl = g.ImageUrl,
                Description = g.Description,
                ReleasedOn = g.ReleasedOn.ToString(DateFormat),
                Publisher = g.Publisher.UserName,
                Genre = g.Genre.Name
            })
            .FirstOrDefaultAsync();
        
        if (model == null) return NotFound();
        
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var currentUserId = GetUserId();
        var gameToDelete = await _context.Games.FindAsync(id);

        if (gameToDelete == null)
        {
            return NotFound();
        }

        if (gameToDelete.PublisherId != currentUserId)
        {
            return Unauthorized();
        }

        var model = new GameDeleteViewModel()
        {
            Id = gameToDelete.Id,
            Title = gameToDelete.Title,
            Publisher = gameToDelete.PublisherId
        };
        
        return View(model);
    }

    [HttpPost]
    [ActionName("DeleteConfirmed")]
    public async Task<IActionResult> Delete(GameDeleteViewModel model, int id)
    {
        var currentUserId = GetUserId();
        var gameToDelete = await _context.Games.FindAsync(id);

        if (gameToDelete == null)
        {
            return RedirectToAction(nameof(Delete));
        }

        if (gameToDelete.PublisherId != currentUserId)
        {
            return RedirectToAction(nameof(Delete));
        }
        
        var gamerGamesToDelete = await _context.GamersGames.Where(gg => gg.GameId == id).ToListAsync();
        
        _context.GamersGames.RemoveRange(gamerGamesToDelete);
        
        _context.Games.Remove(gameToDelete);
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(All));
    } 
    
    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

    private async Task<IEnumerable<GenreViewModel>> GetGenresAsync()
    {
        return await _context.Genres
            .AsNoTracking()
            .Select(g => new GenreViewModel()
            {
                Id = g.Id,
                Name = g.Name,
            })
            .ToListAsync();
    }
}