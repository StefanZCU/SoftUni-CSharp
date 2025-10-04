using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShoppingListApp.Data.Models;

[Comment("Product notes for shopping list")]
public class ProductNote
{
    [Key]
    [Comment("The id of the product note")]
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    [Comment("The content of the product note")]
    public required string Content { get; set; }

    [Required]
    [Comment("Product Identifier")]
    public int ProductId { set; get; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;
}   