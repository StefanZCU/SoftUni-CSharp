using GameZone.Data;
using System.Globalization;
using GameZone.Data.Models;
using GameZone.Models.Game;
using GameZone.Models.Genre;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using static GameZone.Common.Constants.DataConstants;

namespace GameZone.Controllers;

[Authorize]
public class GameController : Controller
{
    private readonly GameZoneDbContext _data;

    public GameController(GameZoneDbContext context)
    {
        _data = context;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var allGames = await _data
            .Games
            .AsNoTracking()
            .Select(g => new GameModel()
            {
                Genre = g.Genre.Name,
                Id = g.Id,
                ImageUrl = g.ImageUrl,
                Publisher = g.Publisher.UserName,
                ReleasedOn = g.ReleasedOn.ToString(DateFormat),
                Title = g.Title
            })
            .ToListAsync();

        return View(allGames);

    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new GameFormModel()
        {
            Genres = GetGenres()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(GameFormModel model)
    {
        if (!DateTime.TryParseExact(
                model.ReleasedOn,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var releasedOn))
        {
            ModelState.AddModelError(nameof(model.ReleasedOn), $"Invalid date format. The format must be: {DateFormat}");
        }
        
        if (GetGenres().All(g => g.Id != model.GenreId))
        {
            ModelState.AddModelError(nameof(model.GenreId), "Genre does not exist!");
        }

        if (!ModelState.IsValid)
        {
            model.Genres = GetGenres();
            
            return View(model);
        }

        string currentUser = GetUserId();
        
        var game = new Game()
        {
            Title = model.Title,
            ImageUrl = model.ImageUrl,
            Description = model.Description,
            ReleasedOn = releasedOn,
            GenreId = model.GenreId,
            PublisherId = currentUser
        };

        await _data.Games.AddAsync(game);
        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var gameToEdit = await _data.Games.FindAsync(id);

        if (gameToEdit == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();

        if (currentUserId != gameToEdit.PublisherId)
        {
            return Unauthorized();
        }

        GameFormModel model = new GameFormModel()
        {
            Description = gameToEdit.Description,
            GenreId = gameToEdit.GenreId,
            Genres = GetGenres(),
            Title = gameToEdit.Title,
            ImageUrl = gameToEdit.ImageUrl,
            ReleasedOn = gameToEdit.ReleasedOn.ToString(DateFormat)
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, GameFormModel model)
    {
        if (!DateTime.TryParseExact(
                model.ReleasedOn,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var releasedOn))
        {
            ModelState.AddModelError(nameof(model.ReleasedOn),
                $"Invalid date format. The format must be: {DateFormat}");
        }

        if (GetGenres().All(g => g.Id != model.GenreId))
        {
            ModelState.AddModelError(nameof(model.GenreId), "Genre does not exist!");
        }

        if (!ModelState.IsValid)
        {
            model.Genres = GetGenres();

            return View(model);
        }

        string currentUser = GetUserId();

        var game = await _data.Games.FindAsync(id);

        if (game == null)
        {
            return BadRequest();
        }

        if (currentUser != game.PublisherId)
        {
            return Unauthorized();
        }

        game.Title = model.Title;
        game.ImageUrl = model.ImageUrl;
        game.Description = model.Description;
        game.ReleasedOn = releasedOn;
        game.GenreId = model.GenreId;

        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> MyZone()
    {
        string currentUserId = GetUserId();

        var usersAddedGames = await _data
            .GamersGames
            .AsNoTracking()
            .Where(gg => gg.GamerId == currentUserId)
            .Select(gg => new GameModel()
            {
                Title = gg.Game.Title,
                Publisher = gg.Game.Publisher.UserName,
                ReleasedOn = gg.Game.ReleasedOn.ToString(DateFormat),
                ImageUrl = gg.Game.ImageUrl,
                Genre = gg.Game.Genre.Name,
                Id = gg.Game.Id
            })
            .ToListAsync();

        return View(usersAddedGames);
    }

    [HttpGet]
    [ActionName("AddToMyZone")]
    public async Task<IActionResult> Join(int id)
    {
        var game = await _data.Games.FindAsync(id);

        if (game == null)
        {
            return BadRequest();
        }

        var gamerGame = new GamerGame()
        {
            GameId = game.Id,
            GamerId = GetUserId()
        };

        if (await _data.GamersGames.ContainsAsync(gamerGame))
        {
            return RedirectToAction(nameof(All));
        }

        await _data.GamersGames.AddAsync(gamerGame);
        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(MyZone));
    }

    [HttpGet]
    public async Task<IActionResult> StrikeOut(int id)
    {
        string currentUserId = GetUserId();
        
        var gamerGame =
            await _data.GamersGames.FirstOrDefaultAsync(gg => gg.GameId == id && gg.GamerId == currentUserId);

        if (gamerGame == null)
        {
            return BadRequest();
        }

        _data.GamersGames.Remove(gamerGame);
        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(MyZone));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = await _data
            .Games
            .AsNoTracking()
            .Where(g => g.Id == id)
            .Select(g => new GameDetailsModel()
            {
                ImageUrl = g.ImageUrl,
                Title = g.Title,
                Description = g.Description,
                Genre = g.Genre.Name,
                ReleasedOn = g.ReleasedOn.ToString(DateFormat),
                Publisher = g.Publisher.UserName,
                Id = g.Id
            })
            .FirstOrDefaultAsync();

        if (model == null)
        {
            return BadRequest();
        }
        
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var game = await _data.Games
            .Include(g => g.Publisher)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (game == null)
        {
            return BadRequest();
        }

        if (GetUserId() != game.PublisherId)
        {
            return Unauthorized();
        }

        var model = new GameDeleteModel()
        {
            Id = id,
            Title = game.Title,
            Publisher = game.Publisher.UserName
        };
        
        return View(model);
    }

    [HttpPost]
    [ActionName("DeleteConfirmed")]
    public async Task<IActionResult> Delete(GameDeleteModel model, int id)
    {
        var game = await _data.Games.FindAsync(id);

        if (game == null)
        {
            return BadRequest();
        }
        
        if (GetUserId() != game.PublisherId)
        {
            return Unauthorized();
        }

        var gamerGames = _data.GamersGames.Where(gg => gg.GameId == id);
        _data.GamersGames.RemoveRange(gamerGames);

        _data.Games.Remove(game);
        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }


    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

    private IEnumerable<GenreModel> GetGenres()
    {
        return _data
            .Genres
            .Select(g => new GenreModel()
            {
                Id = g.Id,
                Name = g.Name
            });
    }
}