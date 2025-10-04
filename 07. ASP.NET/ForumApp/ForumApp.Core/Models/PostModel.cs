using System.ComponentModel.DataAnnotations;
using static ForumApp.Infrastructure.Constants.ValidationConstants;

namespace ForumApp.Core.Models;

/// <summary>
/// Post data transfer model
/// </summary>
public class PostModel
{
    /// <summary>
    /// Post identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Post title
    /// </summary>
    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(maximumLength: PostTitleMaxLength,  MinimumLength = PostTitleMinLength, ErrorMessage = FieldLengthErrorMessage)]
    public string Title { get; set; }

    /// <summary>
    /// Post content
    /// </summary>
    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(maximumLength: PostContentMaxLength,  MinimumLength = PostContentMinLength, ErrorMessage = FieldLengthErrorMessage)]
    public string Content { get; set; }
}