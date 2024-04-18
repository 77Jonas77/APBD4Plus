using APBD5.Model;

namespace APBD5.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string sort);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}