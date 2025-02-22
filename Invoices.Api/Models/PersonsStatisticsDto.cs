namespace Invoices.Api.Models
{
    public class PersonsStatisticsDto
    {
        public ulong personId {  get; set; }
        public string personName { get; set; } = "";
        public decimal revenue { get; set; }

    }
}
