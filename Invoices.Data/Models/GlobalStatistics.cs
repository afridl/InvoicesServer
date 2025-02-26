

namespace Invoices.Data.Models
{
    public class GlobalStatistics
    {
        public decimal CurrentYearSum { get; set; }
        public decimal AllTimeSum { get; set; }
        public ulong InvoicesCount { get; set; }
        public GlobalStatistics(decimal currentYearSum, decimal allTimeSum, ulong invoicesCount)
        {
            CurrentYearSum = currentYearSum;
            AllTimeSum = allTimeSum;
            InvoicesCount = invoicesCount;
        }
    }
}
