using Invoicing.DTOObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Invoicing.AccessData.Configuration
{
    public class CreateUserConfiguration : IEntityTypeConfiguration<CreateUser>
    {
        public void Configure(EntityTypeBuilder<CreateUser> builder)
        {
            builder.Property(c => c.DocumentNumber).IsRequired();
            builder.Property(c => c.DocumentTypeId).IsRequired();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Password).IsRequired().HasMaxLength(50);
            builder.Property(c => c.FirstLoginDate).HasMaxLength(50);
        }
    }
}
