using HouseRentingSystem.Core.Models.Statistics;

namespace HouseRentingSystem.Core.Contracts.StatisticServices;

public interface IStatisticService
{
    Task<StatisticServiceModel> TotalAsync();
}