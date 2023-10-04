using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.Api.Generals;
using Invoicing.DTOObjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly ICreateUserCommandRepository _repoUser;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryRepository repo, ILogger<CategoryController> logger, ICreateUserCommandRepository repoUser)
        {
            _repo = repo;
            _logger = logger;
            _repoUser = repoUser;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            _logger.LogInformation("Get list");
            var LItems = await _repo.GetAll();
            return Ok(LItems);
        }

        [HttpGet(Name = "GetAllUserCommand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CreateUserCommand>>> GetAllUserCommand()
        {
            _logger.LogInformation("Get list");
            var LItems = await _repoUser.GetAll();
            return Ok(LItems);
        }

        //[HttpGet("{id}", Name = "GetCategory")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<Category>> GetById(int id)
        //{
        //    if (id == 0)
        //    {
        //        _logger.LogError("Must send the ID!");
        //        return BadRequest();
        //    }

        //    var Item = await _repo.GetOne(e => e.ID == id);

        //    if (Item == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(Item);
        //}

        //[HttpGet("ByName/{name}", Name = "GetCategoryByName")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<IEnumerable<Category>>> GetByName(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        _logger.LogError("Must send the Name!");
        //        return BadRequest();
        //    }

        //    var LItems = await _repo.GetAll(e => e.Name.ToLower().Contains(name.ToLower()));

        //    if (LItems == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(LItems);
        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<Category>> AddObject([FromBody] Category Item)
        //{
        //    if (Item == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    } 

        //    var itemValidationExists = await _repo.GetOne(c => c.Name.ToLower() == Item.Name.ToLower());

        //    if (itemValidationExists != null)
        //    {
        //        return BadRequest("Object already exists!");
        //    }

        //    await _repo.Insert(Item);
        //    await _repo.SaveChanges();

        //    return CreatedAtRoute("GetCategory", new { id = Item.ID }, Item);
        //}

        //[HttpPatch]
        //[ProducesResponseType(StatusCodes.Status202Accepted)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<Category>> UpdateObject([FromBody] Category Item)
        //{
        //    if (Item == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    string Message = ValidatePropertyIsNullOrEmpty<Category>.ValidateProperty(Item, "ID", "Name");

        //    if (!string.IsNullOrEmpty(Message))
        //    {
        //        return BadRequest(Message);
        //    }

        //    var itemValidationExists = await _repo.GetOne(c => c.ID == Item.ID);

        //    if (itemValidationExists == null)
        //    {
        //        return BadRequest("Object does not exists!");
        //    }

        //    if (!string.IsNullOrEmpty(Item.Name))
        //        itemValidationExists.Name = Item.Name;

        //    _repo.Update(itemValidationExists);

        //    return CreatedAtRoute("GetCategory", new { id = itemValidationExists.ID }, itemValidationExists);
        //}

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult> DeleteObject(int id)
        //{
        //    var Item = await _repo.GetOne(e => e.ID == id);

        //    if (Item == null)
        //    {
        //        return NotFound();
        //    }

        //    _repo.Remove(Item);

        //    return NoContent();
        //}
    }
}
