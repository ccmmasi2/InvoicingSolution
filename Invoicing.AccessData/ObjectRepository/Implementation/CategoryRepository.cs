using Invoicing.AccessData.Data;
using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.AccessData.Repository.Implementation;
using Invoicing.DTOObjects.Models;

namespace Invoicing.AccessData.ObjectRepository.Implementation
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _dbcontext;

        public CategoryRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
