using System.ComponentModel.DataAnnotations;

namespace Cw10.DTOs
{
    public class GetAccountDataResponse
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string Role { get; set; } = null!;
        public ICollection<ShoppingCartDetails>? Cart { get; set; }
    }

    public class ShoppingCartDetails
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Amount { get; set; }
    }
}