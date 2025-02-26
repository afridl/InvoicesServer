using Invoices.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Interfaces
{
    public interface IInvoiceRepository:IBaseRepository<Invoice>
    {

        
        IList<Invoice> FindByBuyerIN(string identificationNumber, int limit);
        IList<Invoice> FindBySellerIN(string identificationNumber, int limit);
        IList<Invoice> FindFiltered(ulong buyerId, ulong sellerId, string product = "", decimal minPrice = -99999999.99m, decimal maxPrice = 99999999.99m, int limit = int.MaxValue);
        
        GlobalStatistics GetGlobalStatistics();


        }
    }
