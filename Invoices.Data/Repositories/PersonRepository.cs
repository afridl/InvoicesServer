

using Invoices.Data.Interfaces;
using Invoices.Data.Models;

namespace Invoices.Data.Repositories;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(InvoicesDbContext invoicesDbContext) : base(invoicesDbContext)
    {
    }


    public IList<Person> GetAllByHidden(bool hidden)
    {
        return dbSet
            .Where(p => p.Hidden == hidden)
            .ToList();
    }
    public IList<PersonsStatistics> GetPersonsStatistics()
    {
        IList<PersonsStatistics> statistics = new List<PersonsStatistics>();

        foreach (Person p in dbSet)
        {
            ulong personId = p.PersonId;
            string personName = p.Name;
            decimal revenue = p.Sells.Sum(s => s.Price) - p.Purchases.Sum(s => s.Price);
            statistics.Add(new PersonsStatistics(personId, personName,revenue));
        }

        return statistics;
    }
}