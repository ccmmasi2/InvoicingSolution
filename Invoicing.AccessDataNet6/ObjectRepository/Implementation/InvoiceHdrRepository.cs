using Invoicing.AccessDataNet6.Data;
using Invoicing.AccessDataNet6.Repository.Implementation;
using Invoicing.DTOObjectsNet6.Models;

namespace Invoicing.AccessDataNet6.ObjectRepository.Interface
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
