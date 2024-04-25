using System.ComponentModel.DataAnnotations;

namespace APBD6.DTOs;

public record ProductFullfillOrderData(
    [Required] int IdProduct,
    [Required] int IdWarehouse,
    [Required] int Amount,
    [Required] DateTime CreatedAt
);