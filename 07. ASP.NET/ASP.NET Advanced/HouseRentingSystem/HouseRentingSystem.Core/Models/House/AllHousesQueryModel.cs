using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Core.Enums;

namespace HouseRentingSystem.Core.Models.House;

public class AllHousesQueryModel
{
    public int HousesPerPage { get; init; } = 3;

    public string Category { get; init; } = null!;

    [Display(Name = "Search by text")]
    public string SearchTerm { get; init; } = null!;

    public HouseSorting Sorting { get; init; }

    public int CurrentPage { get; init; } = 1;

    public int TotalHousesCount { get; set; }

    public IEnumerable<string> Categories { get; set; } = null!;

    public IEnumerable<HouseServiceModel> Houses { get; set; } = new List<HouseServiceModel>();

}