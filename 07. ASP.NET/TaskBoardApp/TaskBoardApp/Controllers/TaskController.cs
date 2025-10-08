using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using Task = TaskBoardApp.Data.Task;

namespace TaskBoardApp.Controllers;

[Authorize]
public class TaskController : Controller
{
    private readonly TaskBoardAppDbContext _dataContext;

    public TaskController(TaskBoardAppDbContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var model = new TaskFormViewModel
        {
            Boards = await GetBoardsAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskFormViewModel model)
    {
        if ((await GetBoardsAsync()).All(b => b.Id != model.BoardId))
        {
            ModelState.AddModelError(nameof(model.BoardId), "Board doesn't exist");
        }

        if (!ModelState.IsValid)
        {
            model.Boards = await GetBoardsAsync();
            return View(model);
        }

        Task task = new Task()
        {
            Title = model.Title,
            Description = model.Description,
            BoardId = model.BoardId,
            CreatedOn = DateTime.Now,
            OwnerId = GetUserId()
        };

        await _dataContext.Tasks.AddAsync(task);
        await _dataContext.SaveChangesAsync();

        return RedirectToAction("Index", "Board");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var task = await _dataContext
            .Tasks
            .Where(t => t.Id == id)
            .Select(t => new TaskDetailsViewModel()
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedOn = t.CreatedOn.Value.ToString("dd/MM/yyyy HH:mm"),
                Board = t.Board.Name,
                Owner = t.Owner.UserName
            })
            .FirstOrDefaultAsync();

        return View(task);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var task = await _dataContext.Tasks.FindAsync(id);

        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();
        if (task.OwnerId != currentUserId)
        {
            return Unauthorized();
        }

        TaskFormViewModel model = new()
        {
            Title = task.Title,
            Description = task.Description,
            BoardId = task.BoardId.Value,
            Boards = await GetBoardsAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, TaskFormViewModel model)
    {
        var task = await _dataContext.Tasks.FindAsync(id);

        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();
        if (task.OwnerId != currentUserId)
        {
            return Unauthorized();
        }

        if ((await GetBoardsAsync()).All(b => b.Id != model.BoardId))
        {
            ModelState.AddModelError(nameof(model.BoardId), "Board doesn't exist");
        }

        if (!ModelState.IsValid)
        {
            model.Boards = await GetBoardsAsync();
            return View(model);
        }

        task.Title = model.Title;
        task.Description = model.Description;
        task.BoardId = model.BoardId;

        await _dataContext.SaveChangesAsync();
        return RedirectToAction("Index", "Board");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _dataContext.Tasks.FindAsync(id);
        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();
        if (task.OwnerId != currentUserId)
        {
            return Unauthorized();
        }

        TaskViewModel model = new TaskViewModel()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(TaskViewModel model)
    {
        var task = await _dataContext.Tasks.FindAsync(model.Id);
        if (task == null)
        {
            return BadRequest();
        }
        
        string currentUserId = GetUserId();
        if (task.OwnerId != currentUserId)
        {
            return Unauthorized();
        }
        
        _dataContext.Tasks.Remove(task);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction("Index", "Board");
    }

    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

    private async Task<IEnumerable<TaskBoardViewModel>> GetBoardsAsync()
    {
        return await _dataContext.Boards
            .Select(b => new TaskBoardViewModel()
            {
                Id = b.Id,
                Name = b.Name,
            })
            .ToListAsync();
    }
}