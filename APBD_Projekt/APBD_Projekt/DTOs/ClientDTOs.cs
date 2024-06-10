using System.ComponentModel.DataAnnotations;

namespace APBD_Projekt.DTOs;

public record CreateClientAsPhysicalRequestDto
{
    [Required] [MaxLength(100)] public required string Address { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public required string Email { get; set; }

    [Required] [StringLength(9)] public required string TelephoneNumber { get; set; }

    [Required] [MaxLength(100)] public required string Name { get; set; }

    [Required] [MaxLength(100)] public required string LastName { get; set; }

    [Required] [StringLength(11)] public required string Pesel { get; set; }
}

public record CreateClientAsCompanyRequestDto
{
    [Required] [MaxLength(100)] public required string Address { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public required string Email { get; set; }

    [Required] [StringLength(9)] public required string TelephoneNumber { get; set; }

    [Required] [MaxLength(100)] public required string CompanyName { get; set; }

    [Required] [StringLength(10)] public required string Krs { get; set; }
}

public record UpdatePhysicalClientRequestDto
{
    [MaxLength(100)] public string? Address { get; set; }

    [EmailAddress] [MaxLength(50)] public string? Email { get; set; }

    [StringLength(9)] public string? TelephoneNumber { get; set; }

    [MaxLength(100)] public string? Name { get; set; }

    [MaxLength(100)] public string? LastName { get; set; }
}

public record UpdateCompanyClientRequestDto
{
    [MaxLength(100)] public string? Address { get; set; }

    [EmailAddress] [MaxLength(50)] public string? Email { get; set; }

    [StringLength(9)] public string? TelephoneNumber { get; set; }

    [MaxLength(100)] public string? CompanyName { get; set; }
}