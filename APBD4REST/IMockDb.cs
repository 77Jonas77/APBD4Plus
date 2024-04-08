namespace APBD4REST;

public interface IMockDb
{
    public ICollection<Animal> GetAll();
    public Animal? GetById(int id);
    public void Add(Animal animal);
    public void Edit(Animal animal);
    public void Delete(int id);
    public ICollection<Visit> GettAllVisits();
    public void AddVisit(Visit visit);
}