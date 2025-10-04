using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ShoppingListApp.Data.Models;

[Comment("Shopping List Product")]
public class Product
{
    [Key]
    [Comment("Product ID")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }
    
    public IList<ProductNote> ProductNotes { get; set; }  = new List<ProductNote>();
}