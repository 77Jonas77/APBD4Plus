using System.ComponentModel.DataAnnotations;

namespace Cw10.Models;

public class Role
{
    [Key] public int PkRole { get; set; }

    [Required] [StringLength(100)] public string Name { get; set; } = null!;
    public ICollection<Account>? Accounts { get; set; }
}