using Invoicing.AccessDataNet6.Data;
using Invoicing.AccessDataNet6.Repository.Implementation;
using Invoicing.DTOObjectsNet6.Models;

namespace Invoicing.AccessDataNet6.ObjectRepository.Interface
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
