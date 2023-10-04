using Invoicing.DTOObjectsNet6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoicing.AccessDataNet6.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Code).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.IDCategory).IsRequired();
           
            builder.HasOne(e => e.Category).WithMany().HasForeignKey(e => e.IDCategory);
        }
    }
} 