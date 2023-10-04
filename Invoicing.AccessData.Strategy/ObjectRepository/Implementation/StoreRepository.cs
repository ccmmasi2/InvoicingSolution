using Invoicing.AccessData.Strategy.Data;
using Invoicing.AccessData.Strategy.ObjectRepository.Interface;
using Invoicing.AccessData.Strategy.Repository.Implementation;
using Invoicing.DTOObjects.Strategy.Models;

namespace Invoicing.AccessData.Strategy.ObjectRepository.Implementation
{
    public class StoreRepository : CrudStrategy<Store>, IStoreRepository
    {
        private readonly AppDbContext _dbcontext;

        public StoreRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
