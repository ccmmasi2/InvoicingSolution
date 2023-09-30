using Invoicing.AccessData.Data;
using Invoicing.AccessData.Repository.Implementation;
using Invoicing.DTOObjects.Models;

namespace Invoicing.AccessData.ObjectRepository.Interface
{
    public class ProductPriceRepository : Repository<ProductPriceDTO>, IProductPriceRepository
    {
        private readonly AppDbContext _dbcontext;

        public ProductPriceRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
