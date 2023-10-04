using Invoicing.AccessData.Data;
using Invoicing.AccessData.ObjectRepository.Interface;
using Invoicing.AccessData.Repository.Implementation;
using Invoicing.DTOObjects.Models;

namespace Invoicing.AccessData.ObjectRepository.Implementation
{
    public class InvoiceDtlRepository : Repository<InvoiceDtl>, IInvoiceDtlRepository
    {
        private readonly AppDbContext _dbcontext;

        public InvoiceDtlRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
