using System.Globalization;
using System.Security.Claims;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models.Event;
using Homies.Models.Type;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homies.Controllers;

[Authorize]
public class EventController : Controller
{
    private readonly HomiesDbContext _data;

    public EventController(HomiesDbContext context)
    {
        _data = context;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var events = await _data
            .Events
            .AsNoTracking()
            .Select(e => new EventInfoViewModel(
                e.Id,
                e.Name,
                e.Start,
                e.Type.Name,
                e.Organiser.UserName
            ))
            .ToListAsync();
        
        return View(events);
    }

    [HttpGet]
    public async Task<IActionResult> Joined()
    {
        string userId = GetUserId();
        
        var model = await _data.EventsParticipants
            .AsNoTracking()
            .Where(ep => ep.HelperId == userId)
            .Select(ep => new EventInfoViewModel(
                ep.EventId,
                ep.Event.Name,
                ep.Event.Start,
                ep.Event.Type.Name,
                ep.Event.Organiser.UserName
            ))
            .ToListAsync();
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Join(int id)
    {
        var eventToFind = await _data.Events
            .Where(e => e.Id == id)
            .Include(e => e.EventsParticipants)
            .FirstOrDefaultAsync();

        if (eventToFind == null)
        {
            return BadRequest();
        }

        var userId = GetUserId();

        if (eventToFind.EventsParticipants.Any(p => p.HelperId == userId)) return RedirectToAction(nameof(All));
        
        eventToFind.EventsParticipants.Add(new EventParticipant()
        {
            EventId = eventToFind.Id,
            HelperId = userId
        });

        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(Joined));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        var eventToFind = await _data.Events
            .Where(e => e.Id == id)
            .Include(e => e.EventsParticipants)
            .FirstOrDefaultAsync();
        
        if (eventToFind == null)
        {
            return BadRequest();
        }

        var userId = GetUserId();

        var ep = eventToFind.EventsParticipants
            .FirstOrDefault(x => x.HelperId == userId);

        if (ep == null)
        {
            return BadRequest();
        }

        eventToFind.EventsParticipants.Remove(ep);

        await _data.SaveChangesAsync();
        
        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new EventFormViewModel
        {
            Types = await GetTypes()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EventFormViewModel model)
    {
        DateTime start = DateTime.Now;
        DateTime end = DateTime.Now;

        if (!DateTime.TryParseExact(
                model.Start, 
                DataConstants.DateFormat, 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None,
                out start))
        {
            ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateFormat}");
        }
        
        if (!DateTime.TryParseExact(
                model.End, 
                DataConstants.DateFormat, 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None,
                out end))
        {
            ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateFormat}");
        }

        if (!ModelState.IsValid)
        {
            model.Types = await GetTypes();

            return View(model);
        }

        var entity = new Event()
        {
            CreatedOn = DateTime.Now,
            Description = model.Description,
            Name = model.Name,
            OrganiserId = GetUserId(),
            TypeId = model.TypeId,
            Start = start,
            End = end
        };

        await _data.Events.AddAsync(entity);
        await _data.SaveChangesAsync();

        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var eventToFind = await _data.Events.FindAsync(id);

        if (eventToFind == null)
        {
            return BadRequest();
        }

        if (eventToFind.OrganiserId != GetUserId())
        {
            return Unauthorized();
        }

        var model = new EventFormViewModel
        {
            Description = eventToFind.Description,
            Name = eventToFind.Name,
            Start = eventToFind.Start.ToString(DataConstants.DateFormat),
            End = eventToFind.End.ToString(DataConstants.DateFormat),
            TypeId = eventToFind.TypeId,
            Types = await GetTypes()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EventFormViewModel model, int id)
    {
        var eventToFind = await _data.Events.FindAsync(id);

        if (eventToFind == null)
        {
            return BadRequest();
        }

        if (eventToFind.OrganiserId != GetUserId())
        {
            return Unauthorized();
        }
        
        DateTime start = DateTime.Now;
        DateTime end = DateTime.Now;

        if (!DateTime.TryParseExact(
                model.Start, 
                DataConstants.DateFormat, 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None,
                out start))
        {
            ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be: {DataConstants.DateFormat}");
        }
        
        if (!DateTime.TryParseExact(
                model.End, 
                DataConstants.DateFormat, 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None,
                out end))
        {
            ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be: {DataConstants.DateFormat}");
        }

        if (!ModelState.IsValid)
        {
            model.Types = await GetTypes();

            return View(model);
        }

        eventToFind.Name = model.Name;
        eventToFind.Description = model.Description;
        eventToFind.Start = start;
        eventToFind.End = end;
        eventToFind.TypeId = model.TypeId;

        
        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = await _data
            .Events
            .AsNoTracking()
            .Where(e => e.Id == id)
            .Select(e => new EventDetailsViewModel()
            {
                Id = e.Id,
                CreatedOn = e.CreatedOn.ToString(DataConstants.DateFormat),
                Description = e.Description,
                End = e.End.ToString(DataConstants.DateFormat),
                Name = e.Name,
                Organiser = e.Organiser.UserName,
                Start = e.Start.ToString(DataConstants.DateFormat),
                Type = e.Type.Name
            })
            .FirstOrDefaultAsync();

        if (model == null)
        {
            return BadRequest();
        }
        
        return View(model);
    }

    private string GetUserId() => User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

    private async Task<IEnumerable<TypeViewModel>> GetTypes()
    {
        return await _data.Types
            .AsNoTracking()
            .Select(t => new TypeViewModel()
            {
                Id = t.Id,
                Name = t.Name
            })
            .ToListAsync();
    }
}