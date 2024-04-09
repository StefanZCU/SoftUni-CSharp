using System.Security.Claims;
using Contacts.Data;
using Contacts.Data.Models;
using Contacts.Models.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Controllers;

[Authorize]
public class ContactsController : Controller
{
    private readonly ContactsDbContext _data;

    public ContactsController(ContactsDbContext context)
    {
        _data = context;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var model = await _data
            .Contacts
            .AsNoTracking()
            .Select(c => new ContactModel()
            {
                FirstName = c.FirstName,
                Address = c.Address ?? "No address",
                ContactId = c.Id,
                Email = c.Email,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                Website = c.Website
            })
            .ToListAsync();
        
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new ContactFormModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ContactFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var contact = new Contact()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Address = model.Address,
            Website = model.Website
        };

        await _data.Contacts.AddAsync(contact);
        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Team()
    {
        string currentUserId = GetUserId();
        
        var contacts = await _data.ApplicationUsersContacts
            .AsNoTracking()
            .Where(auc => auc.ApplicationUserId == currentUserId)
            .Select(auc => auc.Contact)
            .Select(c => new ContactModel()
            {
                FirstName = c.FirstName,
                Address = c.Address ?? "No address",
                ContactId = c.Id,
                Email = c.Email,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                Website = c.Website
            })
            .ToListAsync();
        
        return View(contacts);
    }

    [HttpPost]
    public async Task<IActionResult> AddToTeam(int contactId)
    {
        var currentUserId = GetUserId();
        
        var contactExists = await _data.Contacts.AnyAsync(c => c.Id == contactId);
        if (!contactExists)
        {
            return NotFound();
        }
        
        var alreadyInTeam = await _data.ApplicationUsersContacts.AnyAsync(auc => auc.ApplicationUserId == currentUserId && auc.ContactId == contactId);
        if (alreadyInTeam)
        {
            return RedirectToAction(nameof(All));
        }
        
        var applicationUserContact = new ApplicationUserContact
        {
            ApplicationUserId = currentUserId,
            ContactId = contactId
        };
        
        await _data.ApplicationUsersContacts.AddAsync(applicationUserContact);
        await _data.SaveChangesAsync();
        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromTeam(int contactId)
    {
        var currentUserId = GetUserId();

        var applicationUserContact = await _data.ApplicationUsersContacts.FirstOrDefaultAsync(auc =>
            auc.ApplicationUserId == currentUserId && auc.ContactId == contactId);

        if (applicationUserContact == null)
        {
            return NotFound();
        }

        _data.ApplicationUsersContacts.Remove(applicationUserContact);
        await _data.SaveChangesAsync();

        return RedirectToAction(nameof(Team));
    }
    
    [HttpGet("{contactId}")]
    public async Task<IActionResult> Edit(int contactId)
    {
        var contact = await _data.Contacts.FindAsync(contactId);
    
        if (contact == null)
        {
            return NotFound();
        }
    
        var model = new ContactFormModel()
        {
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
            Address = contact.Address,
            Website = contact.Website
        };
    
        return View(model);
    }
    
    [HttpPost("{contactId}")]
    public async Task<IActionResult> Edit(ContactFormModel model, int contactId)
    {
        var contact = await _data.Contacts.FindAsync(contactId);
    
        if (contact == null)
        {
            return NotFound();
        }
    
        if (!ModelState.IsValid)
        {
            return View(model);
        }
    
        contact.FirstName = model.FirstName;
        contact.LastName = model.LastName;
        contact.Email = model.Email;
        contact.PhoneNumber = model.PhoneNumber;
        contact.Address = model.Address;
        contact.Website = model.Website;
    
        await _data.SaveChangesAsync();
    
        return RedirectToAction(nameof(All));
    }

    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
}