using System.Data.SqlClient;
using APBD5.Model;

namespace APBD5.Repositories;

public class AnimalsRepository(IConfiguration configuration) : IAnimalsRepository
{
    private IConfiguration _configuration = configuration;

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:Default"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = $"SELECT * FROM ANIMAL ORDER BY {orderBy}";

        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();

        while (dr.Read())
        {
            var animal = new Animal(
                dr.GetInt32(0),
                dr.GetString(1),
                dr.IsDBNull(2) ? null : dr.GetString(2),
                dr.GetString(3),
                dr.GetString(4)
            );
            animals.Add(animal);
        }

        return animals;
    }

    public int CreateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:Default"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        if (animal.Description == null)
        {
            cmd.CommandText =
                $"INSERT INTO Animal(Name, Category, Area) VALUES (@1,@2,@3)";
            cmd.Parameters.AddWithValue("@1", animal.Name);
            cmd.Parameters.AddWithValue("@2", animal.Category);
            cmd.Parameters.AddWithValue("@3", animal.Area);
        }
        else
        {
            cmd.CommandText =
                $"INSERT INTO Animal(Name, Description, Category, Area) VALUES (@1,@2,@3,@4)";
            cmd.Parameters.AddWithValue("@1", animal.Name);
            cmd.Parameters.AddWithValue("@2", animal.Description);
            cmd.Parameters.AddWithValue("@3", animal.Category);
            cmd.Parameters.AddWithValue("@4", animal.Area);
        }

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:Default"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = $"UPDATE Animal SET Name=@1, Description=@2,Category=@3, Area=@4 WHERE IdAnimal = @5";
        cmd.Parameters.AddWithValue("@1", animal.Name);
        cmd.Parameters.AddWithValue("@2", animal.Description);
        cmd.Parameters.AddWithValue("@3", animal.Category);
        cmd.Parameters.AddWithValue("@4", animal.Area);
        cmd.Parameters.AddWithValue("@5", animal.IdAnimal);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:Default"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}