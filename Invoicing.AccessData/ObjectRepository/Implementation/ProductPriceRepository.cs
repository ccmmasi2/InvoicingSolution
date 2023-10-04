using Invoicing.AccessData.Data;
using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.AccessData.Repository.Implementation;
using Invoicing.DTOObjects.Models;

namespace Invoicing.AccessData.ObjectRepository.Implementation
{
    public class ProductPriceRepository : Repository<ProductPrice>, IProductPriceRepository
    {
        private readonly AppDbContext _dbcontext;

        public ProductPriceRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
