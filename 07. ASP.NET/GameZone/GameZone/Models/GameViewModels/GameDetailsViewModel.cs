namespace GameZone.Models.GameViewModels;

public class GameDetailsViewModel
{
    public string? ImageUrl { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string ReleasedOn { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public int Id { get; set; }
}