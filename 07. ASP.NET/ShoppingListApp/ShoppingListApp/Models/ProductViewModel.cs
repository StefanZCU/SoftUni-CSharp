using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models;

public class ProductViewModel
{
    public int Id { get; set; }

    [Display(Name = "Product Name")]
    [Required(ErrorMessage = "Field {0} is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Field {0} must be between {2} and {1} characters")]
    public string Name { get; set; } = null!;
}
