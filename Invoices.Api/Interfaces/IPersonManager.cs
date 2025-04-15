
using Invoices.Api.Models;

namespace Invoices.Api.Interfaces;

public interface IPersonManager
{
    IList<PersonDto> GetAllPersons();
    PersonDto AddPerson(PersonDto personDto);
    void DeletePerson(uint personId);
    PersonDto? GetPerson(ulong personId);
    PersonDto? UpdatePerson(PersonDto personDto,ulong personId);
    IList<PersonsStatisticsDto> GetPersonsStatistics();
}