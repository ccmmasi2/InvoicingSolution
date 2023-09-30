using Invoicing.AccessData.Data;
using Invoicing.AccessData.Repository.Implementation;
using Invoicing.DTOObjects.Models;

namespace Invoicing.AccessData.ObjectRepository.Interface
{
    public class StoreRepository : Repository<StoreDTO>, IStoreRepository
    {
        private readonly AppDbContext _dbcontext;

        public StoreRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
