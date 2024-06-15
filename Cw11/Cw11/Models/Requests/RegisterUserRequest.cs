using System.ComponentModel.DataAnnotations;

namespace Cw11.Models;

public class RegisterUserRequest
{
    [EmailAddress] [Required] public string username { get; set; }
    [Required] public string password { get; set; }
}