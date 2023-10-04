﻿using Invoicing.DTOObjectsNet6.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Invoicing.AccessDataNet6.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPrice> ProductPrice { get; set; }
        public DbSet<InvoiceHdr> InvoiceHdr { get; set; }
        public DbSet<InvoiceDtl> InvoiceDtl { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
