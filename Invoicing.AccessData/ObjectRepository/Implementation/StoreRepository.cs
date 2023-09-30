using Invoicing.AccessData.Data;
using Invoicing.AccessData.DTOs;
using Invoicing.AccessData.Repository.Implementation;

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
