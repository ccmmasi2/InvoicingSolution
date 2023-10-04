using Invoicing.AccessData.Strategy.Data;
using Invoicing.AccessData.Strategy.ObjectRepository.Interface;
using Invoicing.AccessData.Strategy.Repository.Implementation;
using Invoicing.DTOObjects.Strategy.Models;

namespace Invoicing.AccessData.Strategy.ObjectRepository.Implementation
{
    public class InvoiceHdrRepository : CrudStrategy<InvoiceHdr>, IInvoiceHdrRepository
    {
        private readonly AppDbContext _dbcontext;

        public InvoiceHdrRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
