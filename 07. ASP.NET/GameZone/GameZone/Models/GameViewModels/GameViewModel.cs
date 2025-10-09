namespace GameZone.Models.GameViewModels;

public class GameViewModel
{
    public string? ImageUrl { get; set; }

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string ReleasedOn { get; set; } = null!;

    public int Id { get; set; }

    public string Publisher { get; set; } = null!;


}