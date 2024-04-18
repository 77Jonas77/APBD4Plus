using System.Data.SqlClient;
using APBD5.Model;
using APBD5.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD5;

[ApiController]
[Route("api/animals/[controller]")]
public class AnimalsController(IAnimalsService studentsService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals(string orderBy = "name")
    {
        var animals = studentsService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult CreateStudent(Animal animal)
    {
        var affectedCount = studentsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateStudent(int id, Animal animal)
    {
        var affectedCount = studentsService.UpdateAnimal(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent(int id)
    {
        var affectedCount = studentsService.DeleteAnimal(id);
        return NoContent();
    }
}