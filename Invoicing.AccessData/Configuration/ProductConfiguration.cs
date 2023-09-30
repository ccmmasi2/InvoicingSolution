﻿using Invoicing.AccessData.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoicing.AccessData.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductDTO>
    {
        public void Configure(EntityTypeBuilder<ProductDTO> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Code).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.IDCategory).IsRequired();
        }
    }
} 