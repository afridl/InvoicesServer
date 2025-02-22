using Invoices.Api.Models;
using Microsoft.AspNetCore.Routing;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Drawing;

namespace Invoices.Api.Interfaces
{
    public interface IInvoiceManager
    {
        //buyerID vybere faktury s daným dodavatelem
        //sellerID vybere faktury s daným odběratelem
        //product získá faktury, které obsahují tento produkt
        //minPrice vybere faktury, které mají částku vyšší nebo rovnou tomuto parametru
        //maxPrice vybere faktury, které mají částku nižší nebo rovnou tomuto parametru
        //limit získá pouze omezený počet faktur
        IList<InvoiceDto> GetAllInvoices();
        InvoiceDto AddInvoice(InvoiceDto invoiceDto);
        InvoiceDto GetInvoice(ulong invoiceId);
        void DeleteInvoice(ulong invoiceID);

        InvoiceDto UpdateInvoice(InvoiceDto invoiceDto, ulong invoiceId);

        IList<InvoiceDto> GetInvoicesBySellerIdentificationNumber(string invoiceIdentificationNumber);
        IList<InvoiceDto> GetInvoicesByBuyerIdentificationNumber(string invoiceIdentificationNumber);
        IList<InvoiceDto> GetFilteredInvoices(ulong buyerId = default, ulong sellerId = default, string product = "", decimal minPrice= -99999999.99m, decimal maxPrice= 99999999.99m, int limit = int.MaxValue);

        GlobalStatisticsDto GetGlobalStatistics();


    }
}
