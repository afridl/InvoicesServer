
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models;

public class Person
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public ulong PersonId { get; set; }
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public string IdentificationNumber { get; set; } = "";
    [Required]
    public string TaxNumber { get; set; } = "";
    [Required]
    public string AccountNumber { get; set; } = "";
    [Required]
    public string BankCode { get; set; } = "";
    [Required]
    public string Iban { get; set; } = "";
    [Required]
    public string Telephone { get; set; } = "";
    [Required]
    public string Mail { get; set; } = "";
    [Required]
    public string Street { get; set; } = "";
    [Required]
    public string Zip { get; set; } = "";
    [Required]
    public string City { get; set; } = "";
    [Required]
    public string Note { get; set; } = "";
    [Required]
    public Country Country { get; set; }
    [Required]
    public bool Hidden { get; set; } = false;
    [Required]
    public virtual IList<Invoice> Purchases { get; set; } = new List<Invoice>();
    [Required]
    public virtual IList<Invoice> Sells { get; set; } = new List<Invoice>();
}