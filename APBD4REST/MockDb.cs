using Microsoft.VisualBasic.CompilerServices;

namespace APBD4REST;

public class MockDb : IMockDb
{
    private static ICollection<Animal> _animals;
    private static ICollection<Visit> _visits;

    public MockDb()
    {
        _animals = new List<Animal>
        {
            new Animal(1, "Krzys", "Mieszaniec", 3, "bury"),
            new Animal(2, "Janek", "Buldog", 15, "Czarny"),
            new Animal(3, "Mateusz", "Doberman", 6, "Czarno-brazowy"),
            new Animal(4, "Pluto", "Husky", 7, "Szary"),
            new Animal(5, "Klamka", "Mieszaniec", 3, "bury")
        };
        _visits = new List<Visit>()
        {
            new Visit(new DateTime(2024, 5, 3), 1, 25),
            new Visit(new DateTime(2025, 2, 22), 2, 25),
            new Visit(new DateTime(2024, 12, 5), 3, 55),
        };
    }

    public ICollection<Animal> GetAll()
    {
        return _animals;
    }

    public Animal? GetById(int id)
    {
        return _animals.FirstOrDefault(animal => animal.Id == id);
    }

    public void Add(Animal animal)
    {
        _animals.Add(animal);
    }

    public void Edit(Animal animal, int id)
    {
        var searchedAnimal = _animals.SingleOrDefault(a => a.Id == id);
        if (searchedAnimal != null)
        {
            searchedAnimal.Category = animal.Category;
            searchedAnimal.Color = animal.Color;
            searchedAnimal.Name = animal.Name;
            searchedAnimal.Weight = animal.Weight;
        }
    }

    public void Delete(int id)
    {
        var searchedAnimal = _animals.SingleOrDefault(a => a.Id == id);
        if (searchedAnimal != null) _animals.Remove(searchedAnimal);
    }

    public ICollection<Visit> GettAllVisits()
    {
        return _visits;
    }

    public void AddVisit(Visit visit)
    {
        _visits.Add(visit);
    }
}