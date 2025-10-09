using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models.CategoryModels;
using SeminarHub.Models.SeminarModels;
using static SeminarHub.Common.Constants.DataConstants;
using static SeminarHub.Common.Constants.ErrorConstants;

namespace SeminarHub.Controllers;

[Authorize]
public class SeminarController : Controller
{
    private readonly SeminarHubDbContext _context;

    public SeminarController(SeminarHubDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new SeminarFormViewModel()
        {
            Categories = await GetCategoriesAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(SeminarFormViewModel model)
    {
        if (!DateTime.TryParseExact(
                model.DateAndTime,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var dateAndTime))
        {
            ModelState.AddModelError(nameof(model.DateAndTime), InvalidDateFormatError);
        }

        if ((await GetCategoriesAsync()).All(c => c.Id != model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesntExistError);
        }

        if (!ModelState.IsValid)
        {
            model.Categories = await GetCategoriesAsync();
            return View(model);
        }

        string currentUserId = GetUserId();

        var seminar = new Seminar()
        {
            Topic = model.Topic,
            Lecturer = model.Lecturer,
            Details = model.Details,
            OrganizerId = currentUserId,
            DateAndTime = dateAndTime,
            Duration = model.Duration,
            CategoryId = model.CategoryId
        };

        await _context.Seminars.AddAsync(seminar);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var allSeminars = await _context
            .Seminars
            .AsNoTracking()
            .Select(s => new SeminarViewModel()
            {
                Topic = s.Topic,
                Lecturer = s.Lecturer,
                Category = s.Category.Name,
                DateAndTime = s.DateAndTime.ToString(DateFormat),
                Organizer = s.Organizer.UserName,
                Id = s.Id
            })
            .ToListAsync();

        return View(allSeminars);
    }

    [HttpGet]
    public async Task<IActionResult> Joined()
    {
        var currentUserId = GetUserId();

        var allSeminars = await _context
            .SeminarParticipants
            .AsNoTracking()
            .Where(s => s.ParticipantId == currentUserId)
            .Select(s => new SeminarViewModel()
            {
                Topic = s.Seminar.Topic,
                Lecturer = s.Seminar.Lecturer,
                Category = s.Seminar.Category.Name,
                DateAndTime = s.Seminar.DateAndTime.ToString(DateFormat),
                Organizer = s.Seminar.Organizer.UserName,
                Id = s.Seminar.Id
            })
            .ToListAsync();

        return View(allSeminars);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var currentUserId = GetUserId();
        var seminarToEdit = await _context.Seminars.FindAsync(id);

        if (seminarToEdit == null)
        {
            return NotFound();
        }

        if (seminarToEdit.OrganizerId != currentUserId)
        {
            return Unauthorized();
        }

        var model = new SeminarFormViewModel()
        {
            Topic = seminarToEdit.Topic,
            Lecturer = seminarToEdit.Lecturer,
            Details = seminarToEdit.Details,
            DateAndTime = seminarToEdit.DateAndTime.ToString(DateFormat),
            Duration = seminarToEdit.Duration,
            CategoryId = seminarToEdit.CategoryId,
            Categories = await GetCategoriesAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SeminarFormViewModel model, int id)
    {
        if (!DateTime.TryParseExact(
                model.DateAndTime,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var dateAndTime))
        {
            ModelState.AddModelError(nameof(model.DateAndTime), InvalidDateFormatError);
        }

        if ((await GetCategoriesAsync()).All(c => c.Id != model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), CategoryDoesntExistError);
        }

        if (!ModelState.IsValid)
        {
            model.Categories = await GetCategoriesAsync();
            return View(model);
        }

        var currentUserId = GetUserId();
        var seminarToEdit = await _context.Seminars.FindAsync(id);
        
        if (seminarToEdit == null)
        {
            return NotFound();
        }

        if (seminarToEdit.OrganizerId != currentUserId)
        {
            return Unauthorized();
        }
        
        seminarToEdit.Topic = model.Topic;
        seminarToEdit.Lecturer = model.Lecturer;
        seminarToEdit.Details = model.Details;
        seminarToEdit.DateAndTime = dateAndTime;
        seminarToEdit.Duration = model.Duration;
        seminarToEdit.CategoryId = model.CategoryId;
        
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Join(int id)
    {
        var seminarToJoin = await _context.Seminars.FindAsync(id);

        if (seminarToJoin == null)
        {
            return NotFound();
        }
        
        var seminarParticipant = new SeminarParticipant()
        {
            Seminar = seminarToJoin,
            ParticipantId = GetUserId()
        };

        if (await _context.SeminarParticipants.AnyAsync(s => 
                s.ParticipantId == seminarParticipant.ParticipantId && 
                s.SeminarId == seminarToJoin.Id))
        {
            return RedirectToAction(nameof(All));
        }
        
        await _context.SeminarParticipants.AddAsync(seminarParticipant);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Joined));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        var currentUserId = GetUserId();
        
        var seminarParticipant = await _context.SeminarParticipants.FirstOrDefaultAsync(sp =>
            sp.SeminarId == id && sp.ParticipantId == currentUserId);

        if (seminarParticipant == null)
        {
            return BadRequest();
        }
        
        _context.SeminarParticipants.Remove(seminarParticipant);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Joined));
        
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = await _context
            .Seminars
            .AsNoTracking()
            .Where(s => s.Id == id)
            .Select(s => new SeminarDetailsViewModel()
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
            return NotFound();
        }
        
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var currentUserId = GetUserId();
        var seminarToDelete = await _context.Seminars.FindAsync(id);

        if (seminarToDelete == null)
        {
            return NotFound();
        }

        if (seminarToDelete.OrganizerId != currentUserId)
        {
            return Unauthorized();
        }

        var model = new SeminarDeleteViewModel()
        {
            Topic = seminarToDelete.Topic,
            DateAndTime = seminarToDelete.DateAndTime,
            Id = seminarToDelete.Id
        };
        
        return View(model);
    }

    [HttpPost]
    [ActionName("DeleteConfirmed")]
    public async Task<IActionResult> Delete(SeminarDeleteViewModel model, int id)
    {
        var currentUserId = GetUserId();
        var seminarToDelete = await _context.Seminars.FindAsync(id);
        
        if (seminarToDelete == null)
        {
            return NotFound();
        }

        if (seminarToDelete.OrganizerId != currentUserId)
        {
            return Unauthorized();
        }

        var seminarParticipants = _context.SeminarParticipants
            .Where(sp => sp.SeminarId == seminarToDelete.Id);
        
        _context.SeminarParticipants.RemoveRange(seminarParticipants);
        
        _context.Seminars.Remove(seminarToDelete);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(All));
    }
    


    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

    private async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }
}