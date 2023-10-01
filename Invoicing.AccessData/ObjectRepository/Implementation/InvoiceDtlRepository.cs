using Invoicing.AccessData.Data;
using Invoicing.AccessData.Repository.Implementation;
using Invoicing.DTOObjects.Models;

namespace Invoicing.AccessData.ObjectRepository.Interface
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
