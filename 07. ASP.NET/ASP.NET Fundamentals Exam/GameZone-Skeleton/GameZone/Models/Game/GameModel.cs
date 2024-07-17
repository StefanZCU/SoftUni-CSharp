namespace GameZone.Models.Game;

public class GameModel
{
    public int Id { get; set; }
    public string Title { set; get; } = null!;
    public string Publisher { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string Genre { get; set; } = null!;
    public string ReleasedOn { get; set; } = null!;
}