﻿/*  _____ _______         _                      _
 * |_   _|__   __|       | |                    | |
 *   | |    | |_ __   ___| |___      _____  _ __| | __  ___ ____
 *   | |    | | '_ \ / _ \ __\ \ /\ / / _ \| '__| |/ / / __|_  /
 *  _| |_   | | | | |  __/ |_ \ V  V / (_) | |  |   < | (__ / /
 * |_____|  |_|_| |_|\___|\__| \_/\_/ \___/|_|  |_|\_(_)___/___|
 *
 *                      ___ ___ ___
 *                     | . |  _| . |  LICENCE
 *                     |  _|_| |___|
 *                     |_|
 *
 *    REKVALIFIKAČNÍ KURZY  <>  PROGRAMOVÁNÍ  <>  IT KARIÉRA
 *
 * Tento zdrojový kód je součástí profesionálních IT kurzů na
 * WWW.ITNETWORK.CZ
 *
 * Kód spadá pod licenci PRO obsahu a vznikl díky podpoře
 * našich členů. Je určen pouze pro osobní užití a nesmí být šířen.
 * Více informací na http://www.itnetwork.cz/licence
 */

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
        return Ok(updatedPerson);
    }
    [HttpGet("persons/statistics")]
    public IActionResult GetPersonsStatistics()
    {
        return Ok(personManager.GetPersonsStatistics());
    }
    
}