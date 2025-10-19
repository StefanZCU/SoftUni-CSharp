using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Core.Enumerators;

namespace HouseRentingSystem.Core.Models.HouseModels;

public class AllHousesQueryModel
{
    public const int HousesPerPage = 3;

    public required string Category { get; init; }

    [Display(Name = "Search by text")]
    public required string SearchTerm { get; init; }

    public HouseSorting Sorting { get; init; }

    public int CurrentPage { get; init; } = 1;

    public int TotalHousesCount { get; set; }

    public IEnumerable<string> Categories { get; set; } = null!;

    public IEnumerable<HouseServiceModel> Houses { get; set; } = new List<HouseServiceModel>();
}