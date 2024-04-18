using APBD5.Model;

namespace APBD5.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}