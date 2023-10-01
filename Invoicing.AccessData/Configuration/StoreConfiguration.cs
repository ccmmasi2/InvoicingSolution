﻿using Invoicing.DTOObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoicing.AccessData.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.City).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(100);
        }
    }
}
