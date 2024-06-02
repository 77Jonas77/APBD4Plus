using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Cw10.Models;

public class Account
{
    [Key] public int PkAccount { get; set; }

    public int FkRole { get; set; }

    [Required] [StringLength(50)] public string FirstName { get; set; } = null!;

    [Required] [StringLength(50)] public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [StringLength(80)]
    public string Email { get; set; } = null!;

    [AllowNull] [StringLength(9)] public string Phone { get; set; } = null!;

    [ForeignKey("FkRole")] public virtual Role Role { get; set; } = null!;
    public ICollection<ShoppingCart> ShoppingCarts { get; set; } = null!;
}