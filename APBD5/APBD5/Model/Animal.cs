using System.ComponentModel.DataAnnotations;

namespace APBD5.Model;

public class Animal
{
    public int IdAnimal { get; set; } // czy required?
    [Required] [MaxLength(200)] public string Name { get; set; }
    [MaxLength(200)] public string? Description { get; set; }
    [Required] [MaxLength(200)] public string Category { get; set; }
    [Required] [MaxLength(200)] public string Area { get; set; }

    public Animal(int idAnimal, string name, string? description, string category, string area)
    {
        IdAnimal = idAnimal;
        Name = name;
        Description = description;
        Category = category;
        Area = area;
    }
}