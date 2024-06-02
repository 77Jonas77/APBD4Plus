using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw10.Models;

public class Product
{
    [Key] public int PkProduct { get; set; }

    [Required] [StringLength(100)] public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")] public decimal Weight { get; set; }

    [Column(TypeName = "decimal(5, 2)")] public decimal Width { get; set; }

    [Column(TypeName = "decimal(5, 2)")] public decimal Height { get; set; }

    [Column(TypeName = "decimal(5, 2)")] public decimal Depth { get; set; }

    public ICollection<ProductCategory> ProductCategories { get; set; } = null!;
    public ICollection<ShoppingCart> ShoppingCarts { get; set; } = null!;
}