using Invoicing.DTOObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoicing.AccessData.Configuration
{
    public class InvoiceHdrConfiguration : IEntityTypeConfiguration<InvoiceHdrDTO>
    {
        public void Configure(EntityTypeBuilder<InvoiceHdrDTO> builder)
        {
            builder.Property(c => c.InvoiceNum).IsRequired();
            builder.Property(c => c.Date).IsRequired();
            builder.Property(c => c.IDClient).IsRequired();
            builder.Property(c => c.IDStore).IsRequired();
        }
    }
}