using Invoicing.AccessData.Data;
using Invoicing.AccessData.DTOs;
using Invoicing.AccessData.Repository.Implementation;

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
