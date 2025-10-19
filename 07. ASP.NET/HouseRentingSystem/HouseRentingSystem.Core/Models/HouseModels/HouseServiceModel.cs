using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.HouseModels;

public class HouseServiceModel
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Address { get; set; }

    [Display(Name = "Image URL")]
    public required string ImageUrl { get; set; }

    [Display(Name = "Price per month")]
    public decimal PricePerMonth { get; set; }
    
    [Display(Name = "Is Rented")]
    public bool IsRented { get; set; }
}