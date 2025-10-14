using GameZoneUpdated.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZoneUpdated.Infrastructure.Data.SeedDb;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        var data = new SeedData();
        
        builder.HasData(data.ActionGenre, data.AdventureGenre, data.FightingGenre, data.SportsGenre, data.RacingGenre, data.StrategyGenre);
    }
}