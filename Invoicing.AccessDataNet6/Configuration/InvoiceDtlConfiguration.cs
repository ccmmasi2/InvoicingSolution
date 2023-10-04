using Invoicing.DTOObjectsNet6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoicing.AccessDataNet6.Configuration
{
    public class InvoiceDtlConfiguration : IEntityTypeConfiguration<InvoiceDtl>
    {
        public void Configure(EntityTypeBuilder<InvoiceDtl> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.InvoiceNum).IsRequired();
            builder.Property(c => c.Order).IsRequired();
            builder.Property(c => c.IDProduct).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.QTY).IsRequired();

            builder.HasOne(e => e.InvoiceHdr).WithMany().HasForeignKey(e => e.InvoiceNum);
            builder.HasOne(e => e.Product).WithMany().HasForeignKey(e => e.IDProduct);
        }
    }
}