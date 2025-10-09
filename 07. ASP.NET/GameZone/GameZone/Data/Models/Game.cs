using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static GameZone.Common.Constants.DataConstants;

namespace GameZone.Data.Models;

public class Game
{
    [Key]
    [Comment("Game Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(GameTitleMaxLength)]
    [Comment("Game Title")]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(GameDescriptionMaxLength)]
    [Comment("Game Description")]
    public string Description { get; set; } = null!;
    
    [Comment("Game Image URL")]
    public string? ImageUrl { get; set; }

    [Required]
    [Comment("Game Publisher Id")]
    public string PublisherId { get; set; } = null!;

    [ForeignKey(nameof(PublisherId))]
    public IdentityUser Publisher { get; set; } = null!;

    [Required]
    [Comment("Game Release Date")]
    public DateTime ReleasedOn { get; set; }

    [Required]
    [Comment("Game Genre Id")]
    public int GenreId { get; set; }

    [ForeignKey(nameof(GenreId))]
    public Genre Genre { get; set; } = null!;
    
    public IEnumerable<GamerGame> GamersGames { get; set; } = new List<GamerGame>();
}