using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
