using AutoMapper;
using Invoices.Api.Interfaces;
using Invoices.Api.Models;
using Invoices.Data.Interfaces;
using Invoices.Data.Models;


namespace Invoices.Api.Managers
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;
        private readonly IPersonRepository personRepository;

        public InvoiceManager(IInvoiceRepository invoiceRepository, IMapper mapper, IPersonRepository personRepository)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
            this.personRepository = personRepository;
        }

        public InvoiceDto AddInvoice(InvoiceDto invoiceDto)
        {
            Invoice invoice = mapper.Map<Invoice>(invoiceDto);
            if (invoice is null) { return null!; }
            invoice.InvoiceID = default;
            invoice.BuyerId = invoice.Buyer?.PersonId;
            invoice.SellerId = invoice.Seller?.PersonId;
            invoice.Buyer = null;
            invoice.Seller = null;
            Invoice addedInvoice = invoiceRepository.Insert(invoice);
            if (addedInvoice.BuyerId is not null)
                addedInvoice.Buyer = personRepository.FindById((ulong)addedInvoice.BuyerId);
            if (addedInvoice.SellerId is not null)
                addedInvoice.Seller = personRepository.FindById((ulong)addedInvoice.SellerId);
            return mapper.Map<InvoiceDto>(addedInvoice);
        }

        public void DeleteInvoice(ulong invoiceID)
        {
            invoiceRepository.Delete(invoiceID);
        }

        public IList<InvoiceDto> GetAllInvoices()
        {
            IList<Invoice> invoices = invoiceRepository.GetAll();
            return mapper.Map<IList<InvoiceDto>>(invoices);
        }

        public InvoiceDto GetInvoice(ulong invoiceId)
        {
            Invoice? invoice = invoiceRepository.FindById(invoiceId);
            return mapper.Map<InvoiceDto>(invoice);
        }

        public IList<InvoiceDto> GetInvoicesByBuyerIdentificationNumber(string invoiceIdentificationNumber)
        {
            IList<Invoice> invoices = invoiceRepository.FindByBuyerIN(invoiceIdentificationNumber, int.MaxValue);
            return mapper.Map<IList<InvoiceDto>>(invoices);
        }

        public IList<InvoiceDto> GetInvoicesBySellerIdentificationNumber(string invoiceIdentificationNumber)
        {
            IList<Invoice> invoices = invoiceRepository.FindBySellerIN(invoiceIdentificationNumber, int.MaxValue);
            return mapper.Map<IList<InvoiceDto>>(invoices);
        }
        public IList<InvoiceDto> GetFilteredInvoices(ulong buyerId = default, ulong sellerId = default, string product = "", decimal minPrice = -99999999.99m, decimal maxPrice = 99999999.99m, int limit = int.MaxValue)
        {
            if(minPrice < -99999999.99m)
                minPrice = -99999999.99m;
            if(maxPrice > 99999999.99m)
                maxPrice = 99999999.99m;



            IList<Invoice> invoices = invoiceRepository.FindFiltered(buyerId, sellerId, product, minPrice, maxPrice, limit);
            return mapper.Map<IList<InvoiceDto>>(invoices);
        }
        public InvoiceDto UpdateInvoice(InvoiceDto invoiceDto, ulong invoiceId) {
            Invoice? invoice = mapper.Map<Invoice>(invoiceDto);
            invoice.InvoiceID = invoiceId;
            invoice.Buyer = null;
            invoice.Seller = null;
            if(!invoiceRepository.ExistsWithId(invoiceId))
            {
                return null!;
            }
            Invoice updatedInvoice = invoiceRepository.Update(invoice);
            if (updatedInvoice.SellerId is not null)
            {
                updatedInvoice.Seller = personRepository.FindById((ulong)updatedInvoice.SellerId);
            }
            if (updatedInvoice.BuyerId is not null) {
                updatedInvoice.Buyer = personRepository.FindById((ulong)updatedInvoice.BuyerId);
            }
            return mapper.Map<InvoiceDto>(updatedInvoice);
        }
        public GlobalStatisticsDto GetGlobalStatistics()
        {
            GlobalStatistics globalStatistics = invoiceRepository.GetGlobalStatistics();
            
            return mapper.Map<GlobalStatisticsDto>(globalStatistics);
            
        }
    }
}
