using Invoicing.AccessData.Data;
using Invoicing.AccessData.DTOs;
using Invoicing.AccessData.Repository.Implementation;

namespace Invoicing.AccessData.ObjectRepository.Interface
{
    public class InvoiceDtlRepository : Repository<InvoiceDtlDTO>, IInvoiceDtlRepository
    {
        private readonly AppDbContext _dbcontext;

        public InvoiceDtlRepository(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
