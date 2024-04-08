using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models.Category;
using SeminarHub.Models.Seminar;
using static SeminarHub.Data.Constants.DataConstants;
using static SeminarHub.Data.Constants.ErrorConstants;

namespace SeminarHub.Controllers;

[Authorize]
public class SeminarController : Controller
{
    private readonly SeminarHubDbContext _data;

    public SeminarController(SeminarHubDbContext context)
    {
        _data = context;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var model = await _data
            .Seminars
            .AsNoTracking()
            .Select(s => new SeminarModel()
            {
                Category = s.Category.Name,
                DateAndTime = s.DateAndTime.ToString(DateFormat),
                Topic = s.Topic,
                Lecturer = s.Lecturer,
                Organizer = s.Organizer.UserName,
                Id = s.Id
            })
            .ToListAsync();

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new SeminarFormModel()
        {
            Categories = GetCategories()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(SeminarFormModel model)
    {
        if (GetCategories().All(c => c.Id != model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesNotExistError);
        }

        if (!ModelState.IsValid)
        {
            model.Categories = GetCategories();
            return View(model);
        }

        var seminar = new Seminar()
        {
            Topic = model.Topic,
            Lecturer = model.Lecturer,
            Details = model.Details,
            DateAndTime = DateTime.ParseExact(model.DateAndTime, DateFormat, CultureInfo.InvariantCulture),
            Duration = model.Duration,
            CategoryId = model.CategoryId,
            OrganizerId = GetUserId()
        };

        await _data.Seminars.AddAsync(seminar);
        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Joined()
    {
        var currentUserId = GetUserId();

        var model = await _data
            .SeminarsParticipants
            .AsNoTracking()
            .Where(s => s.ParticipantId == currentUserId)
            .Select(s => new SeminarModel()
            {
                Category = s.Seminar.Category.Name,
                DateAndTime = s.Seminar.DateAndTime.ToString(DateFormat),
                Topic = s.Seminar.Topic,
                Lecturer = s.Seminar.Lecturer,
                Organizer = s.Seminar.Organizer.UserName,
                Id = s.Seminar.Id
            })
            .ToListAsync();

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var seminar = await _data.Seminars.FindAsync(id);
        if (seminar == null)
        {
            return BadRequest();
        }

        var model = new SeminarFormModel()
        {
            Topic = seminar.Topic,
            Lecturer = seminar.Lecturer,
            Details = seminar.Details,
            DateAndTime = seminar.DateAndTime.ToString(DateFormat),
            Duration = seminar.Duration,
            CategoryId = seminar.CategoryId,
            Categories = GetCategories()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SeminarFormModel model, int id)
    {
        if (GetCategories().All(c => c.Id != model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesNotExistError);
        }

        DateTime date;
        if (!DateTime.TryParseExact(model.DateAndTime, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out date))
        {
            ModelState.AddModelError(nameof(model.DateAndTime),
                $"Invalid date format! Date format must be: {DateFormat}");
        }

        if (!ModelState.IsValid)
        {
            model.Categories = GetCategories();
            return View(model);
        }

        var seminar = await _data.Seminars.FindAsync(id);
        if (seminar == null)
        {
            return BadRequest();
        }

        seminar.Topic = model.Topic;
        seminar.Lecturer = model.Lecturer;
        seminar.Details = model.Details;
        seminar.DateAndTime = date;
        seminar.Duration = model.Duration;
        seminar.CategoryId = model.CategoryId;

        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Join(int id)
    {
        var seminar = await _data.Seminars.FindAsync(id);
        if (seminar == null)
        {
            return BadRequest();
        }

        var participant = new SeminarParticipant()
        {
            SeminarId = id,
            ParticipantId = GetUserId()
        };

        if (_data.SeminarsParticipants.Contains(participant))
        {
            return RedirectToAction(nameof(All));
        }

        await _data.SeminarsParticipants.AddAsync(participant);
        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(Joined));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        string userId = GetUserId();

        var participant =
            await _data.SeminarsParticipants.FirstOrDefaultAsync(sp =>
                sp.SeminarId == id && sp.ParticipantId == userId);

        if (participant == null) return RedirectToAction(nameof(Joined));

        _data.SeminarsParticipants.Remove(participant);
        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(Joined));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = await _data
            .Seminars
            .AsNoTracking()
            .Where(s => s.Id == id)
            .Select(s => new SeminarDetailsModel()
            {
                Topic = s.Topic,
                DateAndTime = s.DateAndTime.ToString(DateFormat),
                Duration = s.Duration,
                Lecturer = s.Lecturer,
                Category = s.Category.Name,
                Details = s.Details,
                Organizer = s.Organizer.UserName,
                Id = s.Id
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
        var seminar = await _data.Seminars.FindAsync(id);
        
        if (seminar == null)
        {
            return BadRequest();
        }

        var model = new SeminarDeleteModel()
        {
            Id = id,
            Topic = seminar.Topic,
            DateAndTime = seminar.DateAndTime
        };
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(SeminarDeleteModel model, int id)
    {
        var seminar = await _data.Seminars.FindAsync(id);
        if (seminar == null)
        {
            return BadRequest();
        }

        var seminarParticipants = _data.SeminarsParticipants.Where(sp => sp.SeminarId == id);
        _data.SeminarsParticipants.RemoveRange(seminarParticipants);
        
        _data.Seminars.Remove(seminar);
        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

    private IEnumerable<CategoryModel> GetCategories()
    {
        return _data
            .Categories
            .Select(c => new CategoryModel()
            {
                Id = c.Id,
                Name = c.Name
            });
    }
}