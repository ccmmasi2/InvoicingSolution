using Invoicing.AccessDataNet6.ObjectRepository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace Invoicing.Functions
{
    public class GetAllCategoriesFunction
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesFunction(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [FunctionName("GetAllCategoriesFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            var LItems = _categoryRepository.GetAll();

            return new OkObjectResult(LItems);
        }
    }
}
