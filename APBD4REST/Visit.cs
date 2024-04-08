using Microsoft.VisualBasic;

namespace APBD4REST;

public class Visit
{
    public DateTime Date { get; set; }
    public int IdAnimal { get; set; }
    public string Describtion { get; set; }
    public float Price { get; set; }

    public Visit(DateTime date, int idAnimal, float price)
    {
        Date = date;
        IdAnimal = idAnimal;
        Describtion = "";
        Price = price;
    }
}