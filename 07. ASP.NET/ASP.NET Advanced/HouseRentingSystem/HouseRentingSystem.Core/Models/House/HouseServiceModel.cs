using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Infrastructure.Data.Constants.DataConstants;

namespace HouseRentingSystem.Core.Models.House;

public class HouseServiceModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(HouseTitleMaxLength, MinimumLength = HouseTitleMinLength, ErrorMessage = StringFieldLengthErrorMessage)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(HouseAddressMaxLength, MinimumLength = HouseAddressMinLength, ErrorMessage = StringFieldLengthErrorMessage)]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = RequiredErrorMessage)]
    [DisplayName("Image URL")]
    public string ImageUrl { get; set; } = null!;
    
    [Required(ErrorMessage = RequiredErrorMessage)]
    [Range(typeof(decimal), HousePricePerMonthMinValue, HousePricePerMonthMaxValue, ErrorMessage = PricePerMonthErrorMessage)]
    [DisplayName("Price Per Month")]
    public decimal PricePerMonth { get; set; }

    [DisplayName("Is Rented")]
    public bool IsRented { get; set; }
}