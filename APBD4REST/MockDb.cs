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
        throw new NotImplementedException();
    }

    public Animal? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Add(Animal animal)
    {
        throw new NotImplementedException();
    }

    public void Edit(Animal animal)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public ICollection<Visit> GettAllVisits()
    {
        throw new NotImplementedException();
    }

    public void AddVisit(Visit visit)
    {
        throw new NotImplementedException();
    }
}