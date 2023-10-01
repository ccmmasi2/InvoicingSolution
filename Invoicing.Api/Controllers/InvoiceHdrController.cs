using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.Api.Generals;
using Invoicing.DTOObjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceHdrController : ControllerBase
    {
        private readonly IInvoiceHdrRepository _repo;
        private readonly ILogger<InvoiceHdrController> _logger;

        public InvoiceHdrController(IInvoiceHdrRepository repo, ILogger<InvoiceHdrController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InvoiceHdr>>> GetAll()
        {
            _logger.LogInformation("Get list");
            var LItems = await _repo.GetAll();
            return Ok(LItems);
        }

        [HttpGet("{invoiceNum}", Name = "GetInvoiceHdr")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InvoiceHdr>> GetById(string invoiceNum)
        {
            if (string.IsNullOrEmpty(invoiceNum))
            {
                _logger.LogError("Must send the Invoice num!");
                return BadRequest();
            }

            var Item = await _repo.GetOne(e => e.InvoiceNum == invoiceNum);

            if (Item == null)
            {
                return NotFound();
            }

            return Ok(Item);
        }  
    }
}
