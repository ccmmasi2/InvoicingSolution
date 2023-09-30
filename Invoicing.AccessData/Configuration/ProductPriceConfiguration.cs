using Invoicing.DTOObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoicing.AccessData.Configuration
{
    public class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPriceDTO>
    {
        public void Configure(EntityTypeBuilder<ProductPriceDTO> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.IDProduct).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.StartDate).IsRequired();
            builder.Property(c => c.EndDate).IsRequired();
        }
    }
}