using Invoicing.AccessData.Strategy.Data;
using Invoicing.AccessData.Strategy.ObjectRepository.Interface;
using Invoicing.AccessData.Strategy.Repository.Implementation;
using Invoicing.DTOObjects.Strategy.Models;

namespace Invoicing.AccessData.Strategy.ObjectRepository.Implementation
{
    public class CategoryRepository : CrudStrategy<Category>, ICategoryRepository
    {
        private readonly AppDbContext _dbcontext;

        public CategoryRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        } 
    }
}
