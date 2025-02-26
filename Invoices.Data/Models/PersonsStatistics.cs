
namespace Invoices.Data.Models
{
    public class PersonsStatistics
    {
        public ulong personId { get; set; }
        public string personName { get; set; } = "";
        public decimal revenue { get; set; }
        public PersonsStatistics(ulong personId, string personName, decimal revenue)
        {
            this.personId = personId;
            this.personName = personName;
            this.revenue = revenue;
        }
    }

}
