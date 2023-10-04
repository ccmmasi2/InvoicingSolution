using Invoicing.AccessDataNet6.Data;
using Invoicing.AccessDataNet6.Repository.Implementation;
using Invoicing.DTOObjectsNet6.Models;

namespace Invoicing.AccessDataNet6.ObjectRepository.Interface
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
