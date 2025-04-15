
using Invoices.Api.Interfaces;
using Invoices.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Api.Controllers;

[Route("api")]
[ApiController]
public class PersonsController : ControllerBase
{
    private readonly IPersonManager personManager;


    public PersonsController(IPersonManager personManager)
    {
        this.personManager = personManager;
    }


    [HttpGet("persons")]
    public IEnumerable<PersonDto> GetPersons()
    {
        return personManager.GetAllPersons();
    }

    [HttpPost("persons")]
    public IActionResult AddPerson([FromBody] PersonDto person)
    {
        PersonDto? createdPerson = personManager.AddPerson(person);
        return StatusCode(StatusCodes.Status201Created, createdPerson);
    }
    [HttpGet("persons/{personId}")]
    public IActionResult GetPerson(ulong personId) {
        PersonDto? personDto = personManager.GetPerson(personId);

        if (personDto is null) { return NotFound(); }
        return Ok(personDto);
    
    }

    [HttpDelete("persons/{personId}")]
    public IActionResult DeletePerson(uint personId)
    {
        personManager.DeletePerson(personId);
        return NoContent();
    }
    [HttpPut("persons/{personId}")]
    public IActionResult UpdatePerson([FromBody] PersonDto personDto,ulong personId)
    {

        PersonDto? updatedPerson = personManager.UpdatePerson(personDto, personId);
        if (updatedPerson is null) { return NotFound(); }
        return Ok(updatedPerson);
    }
    [HttpGet("persons/statistics")]
    public IActionResult GetPersonsStatistics()
    {
        return Ok(personManager.GetPersonsStatistics());
    }
    
}