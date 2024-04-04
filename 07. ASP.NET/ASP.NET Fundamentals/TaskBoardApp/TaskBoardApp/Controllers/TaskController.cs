using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers;

public class TaskController : Controller
{
    private readonly TaskBoardAppDbContext _data;

    public TaskController(TaskBoardAppDbContext context)
    {
        _data = context;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        TaskFormModel taskModel = new TaskFormModel()
        {
            Boards = GetBoards()
        };

        return View(taskModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskFormModel taskModel)
    {
        if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
        {
            ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
        }

        string currentUserId = GetUserId();

        Task task = new Task()
        {
            Title = taskModel.Title,
            Description = taskModel.Description,
            CreatedOn = DateTime.Now,
            BoardId = taskModel.BoardId,
            OwnerId = currentUserId
        };

        await _data.Tasks.AddAsync(task);
        await _data.SaveChangesAsync();

        return RedirectToAction("All", "Board");
    }

    public async Task<IActionResult> Details(int id)
    {
        var task = await _data
            .Tasks
            .Where(t => t.Id == id)
            .Select(t => new TaskDetailsViewModel()
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                Board = t.Board.Name,
                Owner = t.Owner.UserName
            })
            .FirstOrDefaultAsync();

        if (task == null)
        {
            return BadRequest();
        }

        return View(task);

    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var task = await _data.Tasks.FindAsync(id);

        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();

        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        TaskFormModel taskModel = new TaskFormModel()
        {
            Title = task.Title,
            Description = task.Description,
            BoardId = task.BoardId,
            Boards = GetBoards()
        };

        return View(taskModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TaskFormModel taskModel, int id)
    {
        var task = await _data.Tasks.FindAsync(id);

        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();

        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
        {
            ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
        }

        task.Title = taskModel.Title;
        task.Description = taskModel.Description;
        task.BoardId = taskModel.BoardId;

        await _data.SaveChangesAsync();
        return RedirectToAction("All", "Board");

    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _data.Tasks.FindAsync(id);
        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();
        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        TaskViewModel taskModel = new TaskViewModel()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description
        };

        return View(taskModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(TaskViewModel taskModel)
    {
        var task = await _data.Tasks.FindAsync(taskModel.Id);
        if (task == null)
        {
            return BadRequest();
        }

        string currentUserId = GetUserId();
        if (currentUserId != task.OwnerId)
        {
            return Unauthorized();
        }

        _data.Tasks.Remove(task);
        await _data.SaveChangesAsync();
        return RedirectToAction("All", "Board");
    }

    private IEnumerable<TaskBoardModel> GetBoards()
        => _data
            .Boards
            .Select(b => new TaskBoardModel()
            {
                Id = b.Id,
                Name = b.Name
            });

    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
}