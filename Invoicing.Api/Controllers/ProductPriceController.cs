using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.Api.Generals;
using Invoicing.DTOObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Invoicing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : ControllerBase
    {
        private readonly IProductPriceRepository _repo;
        private readonly ILogger<ProductPriceController> _logger;

        public ProductPriceController(IProductPriceRepository repo, ILogger<ProductPriceController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductPrice>>> GetAll()
        {
            _logger.LogInformation("Get list");
            var LItems = await _repo.GetAll();
            return Ok(LItems);
        }

        [HttpGet("{id}", Name = "GetProductPrice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductPrice>> GetById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Must send the ID!");
                return BadRequest();
            }

            var Item = await _repo.GetOne(e => e.ID == id);

            if (Item == null)
            {
                return NotFound();
            }

            return Ok(Item);
        } 

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductPrice>> AddObject([FromBody] ProductPrice Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string Message = ValidatePropertyIsNullOrEmpty<ProductPrice>.ValidateProperty(Item, "IDProduct", "Price", "StartDate");

            if (!string.IsNullOrEmpty(Message))
            {
                return BadRequest(Message);
            } 

            await _repo.Insert(Item);
            await _repo.SaveChanges();

            return CreatedAtRoute("GetProductPrice", new { id = Item.ID }, Item);
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductPrice>> UpdateObject([FromBody] ProductPrice Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string Message = ValidatePropertyIsNullOrEmpty<ProductPrice>.ValidateProperty(Item, "ID");

            if (!string.IsNullOrEmpty(Message))
            {
                return BadRequest(Message);
            }

            var itemValidationExists = await _repo.GetOne(c => c.ID == Item.ID);

            if (itemValidationExists == null)
            {
                return BadRequest("Object does not exists!");
            }

            if (Item.Price != null)
                itemValidationExists.Price = Item.Price;
            if (Item.StartDate != null)
                itemValidationExists.StartDate = Item.StartDate;
            if (Item.EndDate != null)
                itemValidationExists.EndDate = Item.EndDate; 

            _repo.Update(itemValidationExists);

            return CreatedAtRoute("GetProductPrice", new { id = itemValidationExists.ID }, itemValidationExists);
        }

        [HttpDelete("ById{id}", Name = "DeleteProductPriceById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProductPriceById(int id)
        {
            var Item = await _repo.GetOne(e => e.ID == id);

            if (Item == null)
            {
                return NotFound();
            }

            _repo.Remove(Item);

            return NoContent();
        } 
    }
}
