using Invoicing.AccessData.Data;
using Invoicing.AccessData.DTOs;
using Invoicing.AccessData.Repository.Implementation;

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
