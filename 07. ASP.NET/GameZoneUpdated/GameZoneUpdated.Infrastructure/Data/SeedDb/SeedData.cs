using GameZoneUpdated.Infrastructure.Data.Models;

namespace GameZoneUpdated.Infrastructure.Data.SeedDb;

public class SeedData
{
    public Genre ActionGenre { get; set; }

    public Genre AdventureGenre { get; set; }

    public Genre FightingGenre { get; set; }

    public Genre SportsGenre { get; set; }

    public Genre RacingGenre { get; set; }

    public Genre StrategyGenre { get; set; }

    public SeedData()
    {
        SeedGenres();
    }
    
    private void SeedGenres()
    {
        ActionGenre = new Genre()
        {
            Id = 1,
            Name = "Action"
        };

        AdventureGenre = new Genre()
        {
            Id = 2,
            Name = "Adventure"
        };

        FightingGenre = new Genre()
        {
            Id = 3,
            Name = "Fighting"
        };

        SportsGenre = new Genre()
        {
            Id = 4,
            Name = "Sports"
        };

        RacingGenre = new Genre()
        {
            Id = 5,
            Name = "Racing"
        };

        StrategyGenre = new Genre()
        {
            Id = 6,
            Name = "Strategy"
        };
    }
}