using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.Api.Generals;
using Invoicing.DTOObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Invoicing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repo;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientRepository repo, ILogger<ClientController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            _logger.LogInformation("Get list");
            var listObjects = await _repo.GetAll();
            return Ok(listObjects);
        }

        [HttpGet(Name = "GetAllUserCommand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllUserCommand()
        {
            _logger.LogInformation("Get list");
            var listObjects = await _repo.GetAll();
            return Ok(listObjects);
        }

        [HttpGet("{identification}", Name = "GetClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Client>> GetByIdentification(string identification)
        {
            if (string.IsNullOrEmpty(identification))
            {
                _logger.LogError("Must send the Identification!");
                return BadRequest();
            }

            var Item = await _repo.GetOne(e => e.Identification == identification);

            if (Item == null)
            {
                return NotFound();
            }

            return Ok(Item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Client>> AddObject([FromBody] Client Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string Message = ValidatePropertyIsNullOrEmpty<Client>.ValidateProperty(Item, "Identification", "Name", "LastName", "BirthDay", "PhoneNumber", "City", "Address", "Email");

            if (!string.IsNullOrEmpty(Message))
            {
                return BadRequest(Message);
            }

            var itemValidationExists = await _repo.GetOne(c => c.Identification.ToLower() == Item.Identification.ToLower());

            if (itemValidationExists != null)
            {
                return BadRequest("Object already exists!");
            }

            await _repo.Insert(Item);
            await _repo.SaveChanges();

            return CreatedAtRoute("GetClient", new { id = Item.ID }, Item);
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Client>> UpdateObject([FromBody] Client Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string Message = ValidatePropertyIsNullOrEmpty<Client>.ValidateProperty(Item, "Identification");

            if (!string.IsNullOrEmpty(Message))
            {
                return BadRequest(Message);
            }

            var itemValidationExists = await _repo.GetOne(c => c.Identification.ToLower() == Item.Identification.ToLower());

            if (itemValidationExists == null)
            {
                return BadRequest("Object does not exists!");
            }

            if (!string.IsNullOrEmpty(Item.Name))
                itemValidationExists.Name = Item.Name;
            if (!string.IsNullOrEmpty(Item.LastName))
                itemValidationExists.LastName = Item.LastName;
            if (Item.BirthDay != null)
                itemValidationExists.BirthDay = Item.BirthDay;
            if (!string.IsNullOrEmpty(Item.PhoneNumber))
                itemValidationExists.PhoneNumber = Item.PhoneNumber;
            if (!string.IsNullOrEmpty(Item.City))
                itemValidationExists.City = Item.City;
            if (!string.IsNullOrEmpty(Item.Address))
                itemValidationExists.Address = Item.Address;
            if (!string.IsNullOrEmpty(Item.Email))
                itemValidationExists.Email = Item.Email;

            _repo.Update(itemValidationExists);

            return CreatedAtRoute("GetClient", new { id = itemValidationExists.Identification }, itemValidationExists);
        }

        [HttpDelete("{identification}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteEmpleado(string identification)
        {
            var Item = await _repo.GetOne(e => e.Identification == identification);

            if (Item == null)
            {
                return NotFound();
            }

            _repo.Remove(Item);

            return NoContent();
        }
    }
}
