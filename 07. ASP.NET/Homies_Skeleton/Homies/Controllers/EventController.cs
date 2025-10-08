using System.Globalization;
using System.Security.Claims;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homies.Controllers;

[Authorize]
public class EventController : Controller
{
    
    private readonly HomiesDbContext  _context;

    public EventController(HomiesDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> All()
    {
        var events = await _context.Events
            .AsNoTracking()
            .Select(e => new EventInfoViewModel(
                    e.Id,
                    e.Name,
                    e.Start,
                    e.Type.Name,
                    e.Organiser.UserName))
            .ToListAsync();
        
        return View(events);
    }

    [HttpPost]
    public async Task<IActionResult> Join(int id)
    {
        var userId = GetUserId();
        
        var eventToFind = await _context
            .Events
            .Where(e => e.Id == id)
            .Include(e => e.EventParticipants)
            .FirstOrDefaultAsync();

        if (eventToFind == null)
        {
            return NotFound();
        }

        if (eventToFind.EventParticipants.All(ep => ep.HelperId != userId))
        {
            eventToFind.EventParticipants.Add(new EventParticipant
            {
                HelperId = userId,
                EventId = id
            });

            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Joined));
    }

    [HttpGet]
    public async Task<IActionResult> Joined(int id)
    {
        string userId = GetUserId();

        var model = await _context.EventParticipants
            .AsNoTracking()
            .Where(ep => ep.HelperId == userId)
            .Select(ep => new EventInfoViewModel(
                ep.EventId,
                ep.Event.Name,
                ep.Event.Start,
                ep.Event.Type.Name,
                ep.Event.Organiser.UserName)
            )
            .ToListAsync();
        
        return View(model);
    }

    public async Task<IActionResult> Leave(int id)
    {
        var userId = GetUserId();
        
        var eventToFind = await _context
            .Events
            .Where(e => e.Id == id)
            .Include(e => e.EventParticipants)
            .FirstOrDefaultAsync();

        if (eventToFind == null)
        {
            return NotFound();
        }
        
        var ep = eventToFind.EventParticipants.FirstOrDefault(ep => ep.HelperId == userId);

        if (ep == null)
        {
            return Unauthorized();
        }
        
        eventToFind.EventParticipants.Remove(ep);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new EventFormViewModel();
        model.Types = await GetEventTypes();
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EventFormViewModel model)
    {
        DateTime start =  DateTime.Now;
        DateTime end = DateTime.Now;

        if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedStart))
        {
            ModelState.AddModelError(nameof(model.Start), $"Invalid start date! Format must be: {DataConstants.DateFormat}");
        }
        
        if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedEnd))
        {
            ModelState.AddModelError(nameof(model.End), $"Invalid end date! Format must be: {DataConstants.DateFormat}");
        }

        if (!ModelState.IsValid)
        {
            model.Types = await GetEventTypes();
            return View(model);
        }

        var entity = new Event()
        {
            CreatedOn = DateTime.Now,
            Description = model.Description,
            End = end,
            Name = model.Name,
            OrganiserId = GetUserId(),
            Start = parsedStart,
            TypeId = model.TypeId
        };
        
        await _context.Events.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var eventToFind = await _context.Events.FindAsync(id);

        if (eventToFind == null)
        {
            return NotFound();
        }

        if (eventToFind.OrganiserId != GetUserId())
        {
            return Unauthorized();
        }

        var model = new EventFormViewModel()
        {
            Description = eventToFind.Description,
            Name = eventToFind.Name,
            Start = eventToFind.Start.ToString(DataConstants.DateFormat),
            End = eventToFind.End.ToString(DataConstants.DateFormat),
            TypeId = eventToFind.TypeId
        };
        
        model.Types = await GetEventTypes();
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EventFormViewModel model)
    {
        var eventToFind = await _context.Events.FindAsync(id);
        
        if (eventToFind == null)
        {
            return NotFound();
        }

        if (eventToFind.OrganiserId != GetUserId())
        {
            return Unauthorized();
        }
        
        DateTime start =  DateTime.Now;
        DateTime end = DateTime.Now;

        if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedStart))
        {
            ModelState.AddModelError(nameof(model.Start), $"Invalid start date! Format must be: {DataConstants.DateFormat}");
        }
        
        if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedEnd))
        {
            ModelState.AddModelError(nameof(model.End), $"Invalid end date! Format must be: {DataConstants.DateFormat}");
        }

        if (!ModelState.IsValid)
        {
            model.Types = await GetEventTypes();
            return View(model);
        }
        
        eventToFind.Name = model.Name;
        eventToFind.Description = model.Description;
        eventToFind.Start = parsedStart;
        eventToFind.End = parsedEnd;
        eventToFind.TypeId = model.TypeId;
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = await _context
            .Events
            .AsNoTracking()
            .Where(e => e.Id == id)
            .Select(e => new EventDetailesViewModel()
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
            return NotFound();
        }
        
        return View(model);
    }
    

    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

    private async Task<IEnumerable<TypeViewModel>> GetEventTypes()
    {
        return await _context.Types
            .AsNoTracking()
            .Select(t => new TypeViewModel()
            {
                Id = t.Id,
                Name = t.Name,
            })
            .ToListAsync();
    }
}