using System.ComponentModel.DataAnnotations.Schema;

namespace Cw10.Models;

public sealed class ProductCategory
{
    public int FkProduct { get; set; }
    public int FkCategory { get; set; }

    [ForeignKey("FkProduct")] public Product Product { get; set; } = null!;

    [ForeignKey("FkCategory")] public Category Category { get; set; } = null!;
    
}