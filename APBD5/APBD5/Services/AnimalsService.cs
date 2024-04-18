using APBD5.Model;
using APBD5.Repositories;

namespace APBD5.Services;

public class AnimalsService(IAnimalsRepository animalsRepository) : IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository = animalsRepository;

    //todo: logika biznesowa dodac
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        if (orderBy.ToLower() != "name" && orderBy.ToLower() != "description" && orderBy.ToLower() != "category" &&
            orderBy.ToLower() != "area")
        {
            orderBy = "name";
        }

        return _animalsRepository.GetAnimals(orderBy);
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalsRepository.CreateAnimal(animal);
    }

    public int UpdateAnimal(Animal animal)
    {
        return _animalsRepository.UpdateAnimal(animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        return _animalsRepository.DeleteAnimal(idAnimal);
    }
}