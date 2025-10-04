using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static ForumApp.Infrastructure.Constants.ValidationConstants;

namespace ForumApp.Infrastructure.Data.Models;

[Comment("Posts Table")]
public class Post
{
    [Key]
    [Comment("Post Identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(PostTitleMaxLength)]
    [Comment("Post Title")]
    public required string Title { get; set; }

    [Required]
    [MaxLength(PostContentMaxLength)]
    [Comment("Post Content")]
    public required string Content { get; set; }
}