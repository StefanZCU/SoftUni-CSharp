using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Statistics;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services;

public class StatisticService : IStatisticService
{
    private readonly IRepository _repository;

    public StatisticService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<StatisticServiceModel> TotalAsync()
    {
        int totalHouses = await _repository.AllReadOnly<House>()
            .Where(h => h.IsApproved)
            .CountAsync();
        
        int totalRents = await _repository.AllReadOnly<House>()
            .Where(h => h.RenterId != null)
            .CountAsync();
        
        return new StatisticServiceModel
        {
            TotalHouses = totalHouses, 
            TotalRents = totalRents
        };
    }
}