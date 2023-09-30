using Invoicing.AccessData.Data;
using Invoicing.AccessData.DTOs;
using Invoicing.AccessData.Repository.Implementation;

namespace Invoicing.AccessData.ObjectRepository.Interface
{
    public class InvoiceHdrRepository : Repository<InvoiceHdrDTO>, IInvoiceHdrRepository
    {
        private readonly AppDbContext _dbcontext;

        public InvoiceHdrRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
