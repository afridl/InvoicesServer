
using System.Text.Json.Serialization;

namespace Invoices.Api.Models
{
    public class InvoiceDto
    {
        [JsonPropertyName("_id")]
        public ulong InvoiceID { get; set; }
        
        public int InvoiceNumber { get; set; }
        
        public DateTime Issued { get; set; }
        
        public DateTime DueDate { get; set; }
        
        public string Product { get; set; } = "";
        
        public long Price { get; set; }
        
        public int Vat { get; set; }
        
        public string Note { get; set; } = "";

        public ulong BuyerId { get; set; }
        
        public virtual PersonDto? Buyer { get; set; }

        
        public ulong SellerId {  get; set; }
        public virtual PersonDto? Seller { get; set; }
        
    }
}
