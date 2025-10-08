using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers;

[Authorize]
public class BoardController : Controller
{

    private readonly TaskBoardAppDbContext _dataContext;

    public BoardController(TaskBoardAppDbContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<IActionResult> Index()
    {
        var boards = await _dataContext.Boards
            .AsNoTracking()
            .Select(b => new BoardViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Tasks = b.Tasks
                    .Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Description = t.Description,
                        Owner = t.Owner.UserName,
                        Title = t.Title
                    })
            })
            .ToListAsync();
        
        return View(boards);
    }
}