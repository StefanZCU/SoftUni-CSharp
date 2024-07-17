using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data.Models;

public class GamerGame
{
    [Required]
    public int GameId { get; set; }

    [ForeignKey(nameof(GameId))]
    public Game Game { get; set; } = null!;

    [Required]
    public string GamerId { get; set; } = null!;

    [ForeignKey(nameof(GamerId))]
    public IdentityUser Gamer { get; set; } = null!;
}