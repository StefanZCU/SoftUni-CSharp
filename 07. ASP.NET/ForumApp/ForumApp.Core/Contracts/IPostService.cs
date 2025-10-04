using ForumApp.Core.Models;

namespace ForumApp.Core.Contracts;

public interface IPostService
{
    Task<IEnumerable<PostModel>> GetAllPostsAsync();
    Task AddPostAsync(PostModel model);
    Task<PostModel?> GetPostByIdAsync(int id);
    Task EditPostAsync(PostModel model);
    Task DeletePostAsync(int id);
}