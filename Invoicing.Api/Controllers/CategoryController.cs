using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.DTOObjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryRepository repo, ILogger<CategoryController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            _logger.LogInformation("Get list categories");
            var listCategory = await _repo.GetAll();
            return Ok(listCategory);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Category>> GetById(int id)
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
        public async Task<ActionResult<Category>> AddObject([FromBody] Category Item)
        {
            if (Item == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var empleadoExiste = await _repo.GetOne(
                                         c => c.Name.ToLower() == Item.Name.ToLower()
                                        );

            if (empleadoExiste != null)
            {
                return BadRequest("Object already exists!");
            }

            await _repo.Insert(Item);
            await _repo.SaveChanges();

            return CreatedAtRoute("GetCategory", new { id = Item.ID }, Item);  
        }
    }
}
