using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.Core.Services.Interface;

namespace Invoicing.Core.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }
    }
} 