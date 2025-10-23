namespace HouseRentingSystem.Core.Models.HouseModels;

public class HouseDetailsViewModel
{
    public int Id { get; set; }

    public required string Title { get; set; } 

    public required string Address { get; set; } 

    public required string ImageUrl { get; set; } 
}