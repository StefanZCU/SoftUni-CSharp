using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;
    
    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<PostModel> model = await _postService.GetAllPostsAsync();
        
        return View(model);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var model = new PostModel();
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(PostModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        await _postService.AddPostAsync(model);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        PostModel? model = await _postService.GetPostByIdAsync(id);

        if (model == null)
        {
            ModelState.AddModelError("All", "Post not found");
        }
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PostModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        await _postService.EditPostAsync(model);
        return RedirectToAction(nameof(Index));
        
    }

    [HttpPost]
    public async Task<ActionResult> Delete(int id)
    {
        await _postService.DeletePostAsync(id);
        return RedirectToAction(nameof(Index));
    }
}