using Invoicing.DTOObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Invoicing.AccessData.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<CategoryDTO> Categories { get; set; }
        public DbSet<StoreDTO> Stores { get; set; }
        public DbSet<ClientDTO> Clients { get; set; }
        public DbSet<ProductDTO> Products { get; set; }
        public DbSet<ProductPriceDTO> ProductPrices { get; set; }
        public DbSet<InvoiceHdrDTO> InvoicesHdr { get; set; }
        public DbSet<InvoiceDtlDTO> InvoicesDtl { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
