using Invoicing.AccessData.Data;
using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.AccessData.Repository.Implementation;
using Invoicing.DTOObjects.Models;

namespace Invoicing.AccessData.ObjectRepository.Implementation
{
    public class CreateUserRepository : Repository<CreateUser>, ICreateUserRepository
    {
        private readonly AppDbContext _dbcontext;

        public CreateUserRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
