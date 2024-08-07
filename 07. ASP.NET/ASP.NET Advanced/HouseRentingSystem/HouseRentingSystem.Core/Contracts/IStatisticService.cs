using HouseRentingSystem.Core.Models.Statistics;

namespace HouseRentingSystem.Core.Contracts;

public interface IStatisticService
{
    Task<StatisticServiceModel> TotalAsync();
}