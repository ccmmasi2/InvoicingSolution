using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.Api.Generals;
using Invoicing.DTOObjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _repo;
        private readonly ILogger<StoreController> _logger;

        public StoreController(IStoreRepository repo, ILogger<StoreController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Store>>> GetAll()
        {
            _logger.LogInformation("Get list");
            var listObjects = await _repo.GetAll();
            return Ok(listObjects);
        }

        [HttpGet("{id}", Name = "GetStore")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Store>> GetById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Must send the ID");
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
        public async Task<ActionResult<Store>> AddObject([FromBody] Store Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string Message = ValidatePropertyIsNullOrEmpty<Store>.ValidateProperty(Item, "Name", "City", "Address");

            if (!string.IsNullOrEmpty(Message))
            {
                return BadRequest(Message);
            }

            var itemValidationExists = await _repo.GetOne(c => c.Name.ToLower() == Item.Name.ToLower());

            if (itemValidationExists != null)
            {
                return BadRequest("Object already exists!");
            }

            await _repo.Insert(Item);
            await _repo.SaveChanges();

            return CreatedAtRoute("GetStore", new { id = Item.ID }, Item);
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Store>> UpdateObject([FromBody] Store Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string Message = ValidatePropertyIsNullOrEmpty<Store>.ValidateProperty(Item, "ID");

            if (!string.IsNullOrEmpty(Message))
            {
                return BadRequest(Message);
            }

            var itemValidationExists = await _repo.GetOne(c => c.ID == Item.ID);

            if (itemValidationExists == null)
            {
                return BadRequest("Object does not exists!");
            }

            if (!string.IsNullOrEmpty(Item.Name))
                itemValidationExists.Name = Item.Name;
            if (!string.IsNullOrEmpty(Item.City))
                itemValidationExists.City = Item.City;
            if (!string.IsNullOrEmpty(Item.Address))
                itemValidationExists.Address = Item.Address;

            _repo.Update(itemValidationExists);

            return CreatedAtRoute("GetStore", new { id = itemValidationExists.ID }, itemValidationExists);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteEmpleado(int id)
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
