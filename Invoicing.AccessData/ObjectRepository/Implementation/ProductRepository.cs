using Invoicing.AccessData.Data;
using Invoicing.AccessData.Repository.Implementation;
using Invoicing.DTOObjects.Models;

namespace Invoicing.AccessData.ObjectRepository.Interface
{
    public class ProductRepository : Repository<ProductDTO>, IProductRepository
    {
        private readonly AppDbContext _dbcontext;

        public ProductRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
