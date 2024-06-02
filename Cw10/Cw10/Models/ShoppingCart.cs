using System.ComponentModel.DataAnnotations.Schema;

namespace Cw10.Models;

public class ShoppingCart
{
    public int FkAccount { get; set; }
    public int FkProduct { get; set; }
    public int Amount { get; set; }

    [ForeignKey("FkAccount")] public virtual Account Account { get; set; } = null!;

    [ForeignKey("FkProduct")] public virtual Product Product { get; set; } = null!;
}