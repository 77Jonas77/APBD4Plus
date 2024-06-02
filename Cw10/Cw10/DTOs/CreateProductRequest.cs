using System.ComponentModel.DataAnnotations;

namespace Cw10.DTOs;

public class CreateProductRequest
{
    [Required] public string ProductName { get; set; } = null!;
    [Required] public decimal ProductWeight { get; set; }
    [Required] public decimal ProductWidth { get; set; }
    [Required] public decimal ProductHeight { get; set; }
    [Required] public decimal ProductDepth { get; set; }
    [Required] public List<int> ProductCategories { get; set; } = new List<int>();
}