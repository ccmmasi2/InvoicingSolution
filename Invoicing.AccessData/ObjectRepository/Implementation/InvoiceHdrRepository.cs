using Invoicing.AccessData.Data;
using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.AccessData.Repository.Implementation;
using Invoicing.DTOObjects.Models;

namespace Invoicing.AccessData.ObjectRepository.Implementation
{
    public class InvoiceHdrRepository : Repository<InvoiceHdr>, IInvoiceHdrRepository
    {
        private readonly AppDbContext _dbcontext;

        public InvoiceHdrRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
