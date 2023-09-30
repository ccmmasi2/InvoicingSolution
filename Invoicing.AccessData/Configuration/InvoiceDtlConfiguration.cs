using Invoicing.AccessData.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoicing.AccessData.Configuration
{
    public class InvoiceDtlConfiguration : IEntityTypeConfiguration<InvoiceDtlDTO>
    {
        public void Configure(EntityTypeBuilder<InvoiceDtlDTO> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.InvoiceNum).IsRequired();
            builder.Property(c => c.Order).IsRequired();
            builder.Property(c => c.IDProduct).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.QTY).IsRequired();
        }
    }
}