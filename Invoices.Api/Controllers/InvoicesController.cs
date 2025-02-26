using Invoices.Api.Interfaces;

using Invoices.Api.Models;
using Microsoft.AspNetCore.Mvc;




namespace Invoices.Api.Controllers;


[Route("api")]
[ApiController]
public class InvoicesController : ControllerBase
{
    private readonly IInvoiceManager invoiceManager;

    public InvoicesController(IInvoiceManager invoiceManager)
    {
        this.invoiceManager = invoiceManager;
    }
    
    [HttpGet("invoices/{invoiceId}")]
    public IActionResult GetInvoice(ulong invoiceId)
    {
        InvoiceDto invoiceDto = invoiceManager.GetInvoice(invoiceId);
        if (invoiceDto == null)
        {
            return NotFound();
        }

        return Ok(invoiceDto);
    }
    [HttpPost("invoices")]
    public IActionResult AddInvoice([FromBody] InvoiceDto invoiceDto)
    {
        InvoiceDto createdInvoice = invoiceManager.AddInvoice(invoiceDto);
        return StatusCode(StatusCodes.Status201Created, createdInvoice);

    }
    [HttpDelete("invoices/{invoiceId}")]
    public IActionResult DeleteInvoice(ulong invoiceId)
    {
        invoiceManager.DeleteInvoice(invoiceId);
        return NoContent();

    }
    [HttpPut("invoices/{invoiceId}")]
    public IActionResult UpdateInvoice([FromBody] InvoiceDto invoiceDto, ulong invoiceId)
    {
        if (invoiceDto == null) {return BadRequest();}
        InvoiceDto? updatedInvoiceDto =invoiceManager.UpdateInvoice(invoiceDto, invoiceId);  
        if (updatedInvoiceDto == null) { return NotFound(); }
        return Ok(updatedInvoiceDto);
    }
    [HttpGet("identification/{identificationNumber}/sales")]
    public IActionResult GetInvoicesBySellerIdentificationNumber(string identificationNumber)
    {
        
        return Ok(invoiceManager.GetInvoicesBySellerIdentificationNumber(identificationNumber));
    }
    [HttpGet("identification/{identificationNumber}/purchases")]
    public IActionResult GetInvoicesByBuyerIdentificationNumber(string identificationNumber)
    {

        return Ok(invoiceManager.GetInvoicesByBuyerIdentificationNumber(identificationNumber));
    }
    [HttpGet("invoices")]
    public IActionResult GetFilteredInvoices([FromQuery] ulong buyerId, [FromQuery] ulong sellerId, [FromQuery] string product="", [FromQuery] decimal minPrice= -99999999.99m, [FromQuery] decimal maxPrice= 99999999.99m, [FromQuery]int limit=int.MaxValue)
    {
        IList<InvoiceDto> invoicesDto = invoiceManager.GetFilteredInvoices(buyerId,sellerId,product,minPrice,maxPrice,limit);
        return Ok(invoicesDto);
    }
    [HttpGet("invoices/statistics")]
    public IActionResult GetGlobalStatistics()
    {
        return Ok(invoiceManager.GetGlobalStatistics());
    }
    
}
