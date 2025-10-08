using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers;

public class HomeController : Controller
{
    private readonly TaskBoardAppDbContext _dataContext;

    public HomeController(TaskBoardAppDbContext context)
    {
        _dataContext = context;
    }

    public async Task<IActionResult> Index()
    {
        var taskBoards = await _dataContext
            .Boards
            .Select(b => b.Name)
            .ToListAsync();

        var tasksCount = new List<HomeBoardViewModel>();
        foreach (var boardName in taskBoards)
        {
            var tasksInBoard = await _dataContext.Tasks.CountAsync(t => t.Board.Name == boardName);
            tasksCount.Add(new HomeBoardViewModel()
            {
                BoardName = boardName,
                TasksCount = tasksInBoard
            });
        }

        var userTasksCounts = -1;

        if (User.Identity.IsAuthenticated)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            userTasksCounts = await _dataContext.Tasks.CountAsync(t => t.OwnerId == currentUserId);
        }

        var homeModel = new HomeViewModel()
        {
            AllTasksCount = _dataContext.Tasks.Count(),
            BoardsWithTasksCount = tasksCount,
            UserTasksCount = userTasksCounts
        };
        
        return View(homeModel);
    } 
}