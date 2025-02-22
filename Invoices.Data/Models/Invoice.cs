using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Models
{
    public class Invoice
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong InvoiceID { get; set; }
        [Required]
        public int InvoiceNumber { get; set; }
        [Required]
        public DateTime Issued {  get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public string Product { get; set; } = "";
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Vat {  get; set; }
        [Required]
        public string Note { get; set; } = "";

        [ForeignKey(nameof(Buyer))]
        public ulong? BuyerId { get; set; }
        
        [Required]
        public virtual Person? Buyer { get; set; }

        [ForeignKey(nameof(Seller))]
        public ulong? SellerId { get; set; }
        [Required]
        public virtual Person? Seller { get; set; }
    }
}
