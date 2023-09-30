using Invoicing.AccessData.Data;
using Invoicing.AccessData.Repository.Implementation;
using Invoicing.DTOObjects.Models;

namespace Invoicing.AccessData.ObjectRepository.Interface
{
    public class ClientRepository : Repository<ClientDTO>, IClientRepository
    {
        private readonly AppDbContext _dbcontext;

        public ClientRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
