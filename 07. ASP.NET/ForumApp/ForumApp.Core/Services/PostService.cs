using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ForumApp.Core.Services;

public class PostService : IPostService
{
    private readonly ForumAppDbContext _context;
    private readonly ILogger _logger;

    public PostService(
        ForumAppDbContext context,
        ILogger<PostService> logger)
    {
        _context = context;
        _logger = logger;
    }


    public async Task<IEnumerable<PostModel>> GetAllPostsAsync()
    {
        return await _context.Posts
            .AsNoTracking()
            .Select(p => new PostModel()
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
            })
            .ToListAsync();
    }

    public async Task AddPostAsync(PostModel model)
    {
        var entity = new Post()
        {
            Title = model.Title,
            Content = model.Content
        };
        
        try
        {
            await _context.Posts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "PostService.AddPostAsync");
            
            throw new ApplicationException("Operation failed. Please try again.");
        }
    }

    public async Task<PostModel?> GetPostByIdAsync(int id)
    {
        return await _context.Posts
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new PostModel()
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
            })
            .FirstOrDefaultAsync();
    }

    public async Task EditPostAsync(PostModel model)
    {
        var entity = await GetEntityByIdAsync(model.Id);
        
        entity.Title = model.Title;
        entity.Content = model.Content;
        
        await _context.SaveChangesAsync();
    }

    public async Task DeletePostAsync(int id)
    {
        var entity = await GetEntityByIdAsync(id);
        
        _context.Posts.Remove(entity);
        await _context.SaveChangesAsync();
    }

    private async Task<Post> GetEntityByIdAsync(int id)
    {
        var entity = await _context.Posts.FindAsync(id);

        return entity ?? throw new ApplicationException("Post not found");
    }
}