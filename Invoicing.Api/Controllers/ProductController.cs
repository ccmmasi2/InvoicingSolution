using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.Api.Generals;
using Invoicing.DTOObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Invoicing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository repo, ILogger<ProductController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            _logger.LogInformation("Get list");
            var LItems = await _repo.GetAll(includeProperties: "Category");
            return Ok(LItems);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetById(int id)
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

        [HttpGet("ByName/{filter}", Name = "GetProductByFilter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetByFilter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                _logger.LogError("Must send the Name or the Code!");
                return BadRequest();
            }

            var LItems = await _repo.GetAll(
                                            e => e.Name.ToLower().Contains(filter.ToLower()) || 
                                                 e.Code.ToLower().Contains(filter.ToLower())
                                            );

            if (LItems == null)
            {
                return NotFound();
            }

            return Ok(LItems);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> AddObject([FromBody] Product Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string Message = ValidatePropertyIsNullOrEmpty<Product>.ValidateProperty(Item, "Code", "Name", "IDCategory");

            if (!string.IsNullOrEmpty(Message))
            {
                return BadRequest(Message);
            }

            var itemValidationExists = await _repo.GetOne(
                                            e => e.Code == Item.Code ||
                                                 e.Name == Item.Name
                                            );

            if (itemValidationExists != null)
            {
                return BadRequest("Object already exists!");
            }

            await _repo.Insert(Item);
            await _repo.SaveChanges();

            return CreatedAtRoute("GetProduct", new { id = Item.ID }, Item);
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> UpdateObject([FromBody] Product Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string Message = ValidatePropertyIsNullOrEmpty<Product>.ValidateProperty(Item, "ID");

            if (!string.IsNullOrEmpty(Message))
            {
                return BadRequest(Message);
            }

            var itemValidationExists = await _repo.GetOne(c => c.ID == Item.ID);

            if (itemValidationExists == null)
            {
                return BadRequest("Object does not exists!");
            }

            if (!string.IsNullOrEmpty(Item.Code))
                itemValidationExists.Code = Item.Code;
            if (!string.IsNullOrEmpty(Item.Name))
                itemValidationExists.Name = Item.Name;
            if (Item.IDCategory != null && Item.IDCategory != 0)
                itemValidationExists.IDCategory = Item.IDCategory;

            _repo.Update(itemValidationExists);

            return CreatedAtRoute("GetProduct", new { id = itemValidationExists.ID }, itemValidationExists);
        }

        [HttpDelete("ById{id}", Name = "DeleteProductById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProductById(int id)
        {
            var Item = await _repo.GetOne(e => e.ID == id);

            if (Item == null)
            {
                return NotFound();
            }

            _repo.Remove(Item);

            return NoContent();
        }

        [HttpDelete("ByCode{Code}", Name = "DeleteProductByCode")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProductByCode(string Code)
        {
            var Item = await _repo.GetOne(e => e.Code == Code);

            if (Item == null)
            {
                return NotFound();
            }

            _repo.Remove(Item);

            return NoContent();
        }

        [HttpDelete("byName{name}", Name = "DeleteProductByName")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProductByName(string name)
        {
            var Item = await _repo.GetOne(e => e.Name == name);

            if (Item == null)
            {
                return NotFound();
            }

            _repo.Remove(Item);

            return NoContent();
        }
    }
}
