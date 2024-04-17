using System.Data.SqlClient;
using APBD5.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace APBD5;

[ApiController]
[Route("api/animals/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AnimalsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetAllStudents(string sort = "ASC")
    {
        var response = new List<GetAnimalsResponse>();
        using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            var sqlCommand = new SqlCommand($"SELECT * FROM Animal ORDER BY {sort}", sqlConnection);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                response.Add(new GetAnimalsResponse(reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                    )
                );
            }
        }

        return Ok(response);
    }
}