using Invoices.Data.Interfaces;
using Invoices.Data.Models;


namespace Invoices.Data.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InvoicesDbContext invoicesDbContext) : base(invoicesDbContext)
        {
        }

        

        public IList<Invoice> FindByBuyerIN(string identificationNumber, int limit=int.MaxValue)
        {
            return dbSet.Where(i => i.Buyer!.IdentificationNumber == identificationNumber).Take(limit).ToList();
        }

        
        public IList<Invoice> FindBySellerIN(string identificationNumber, int limit=int.MaxValue)
        {
            
            return dbSet.Where(i => i.Seller!.IdentificationNumber == identificationNumber).ToList();
        }
        public IList<Invoice> FindFiltered( ulong buyerId=default, ulong sellerId = default,  string product = "",  decimal minPrice = -99999999.99m,  decimal maxPrice = 99999999.99m, int limit = int.MaxValue) {

            IList<Invoice> query = dbSet.Where(i => i.Price<maxPrice && i.Price>minPrice).ToList();
            if(buyerId != default)
                query = query.Where(i => i.Buyer?.PersonId == buyerId).ToList();
            if(sellerId != default)
                query = query.Where(i=>i.Seller?.PersonId == sellerId).ToList();
            if (product != "")
                query = query.Where(i => i.Product ==  product).ToList();
            query = query.Take(limit).ToList();

            return query;
        }
        public GlobalStatistics GetGlobalStatistics() {
            decimal currentYearSum = dbSet.Where(i => i.DueDate.Year == DateTime.Now.Year).Sum(i => i.Price);
            decimal allTimeSum = dbSet.Sum(i => i.Price);
            ulong invoicesCount = (ulong)dbSet.Count();

            return new GlobalStatistics(currentYearSum,allTimeSum,invoicesCount);
                
        }
    }
}
