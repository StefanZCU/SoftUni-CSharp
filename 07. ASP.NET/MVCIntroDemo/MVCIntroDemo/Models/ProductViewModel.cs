namespace MVCIntroDemo.Models;

/// <summary>
/// Product Model
/// </summary>

public class ProductViewModel
{
    /// <summary>
    /// Product Identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Product Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Product Price with VAT
    /// </summary>
    public int Price { get; set; }
}