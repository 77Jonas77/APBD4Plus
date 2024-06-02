using System.ComponentModel.DataAnnotations;

namespace Cw10.Models;

public class Category
{
    [Key] public int PkCategory { get; set; }

    [Required] [StringLength(100)] public string Name { get; set; } = null!;
    public IEnumerable<ProductCategory>? ProductsCategories { get; set; }
}