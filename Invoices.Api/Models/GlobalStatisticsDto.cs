namespace Invoices.Api.Models
{
    public class GlobalStatisticsDto
    {
        public decimal CurrentYearSum { get; set; }
        public decimal AllTimeSum { get; set; }
        public ulong InvoicesCount { get; set; }
    }
}
