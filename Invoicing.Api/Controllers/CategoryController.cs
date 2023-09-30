using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.DTOObjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController
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
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
        {
            _logger.LogInformation("Get list Categories");
            var listCategory = await _repo.GetAll();
            return Ok(lista);
        }

    }
}
