using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoicing.AccessData.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20233009_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Invoicing.DTOObjects.Models.Category", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(50)");

                b.HasKey("ID");

                b.ToTable("Category");
            });

            modelBuilder.Entity("Invoicing.DTOObjects.Models.Store", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("City")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Address")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.HasKey("ID");

                b.ToTable("Store");
            });

            modelBuilder.Entity("Invoicing.DTOObjects.Models.Client", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                b.Property<string>("Identification")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<DateTime>("BirthDay")
                    .IsRequired()
                    .HasColumnType("Date");

                b.Property<string>("PhoneNumber")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("City")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Address")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.HasKey("ID");

                b.HasIndex("Identification");

                b.ToTable("Client");
            });

            modelBuilder.Entity("Invoicing.DTOObjects.Models.Product", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                b.Property<string>("Code")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<int>("IDCategory")
                    .IsRequired()
                    .HasColumnType("int");

                b.HasKey("ID");

                b.HasIndex("IDCategory");

                b.ToTable("Product");
            });

            modelBuilder.Entity("Invoicing.DTOObjects.Models.ProductPrice", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                b.Property<int>("IDProduct")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<double>("Price")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("numeric(18,2)");

                b.Property<DateTime>("StartDate")
                    .IsRequired()
                    .HasColumnType("Date");

                b.Property<DateTime>("EndDate")
                    .HasColumnType("Date");

                b.HasKey("ID");

                b.HasIndex("IDProduct");

                b.ToTable("ProductPrice");
            });

            modelBuilder.Entity("Invoicing.DTOObjects.Models.InvoiceHdr", b =>
            {
                b.Property<string>("InvoiceNum")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<DateTime>("Date")
                    .IsRequired()
                    .HasColumnType("Date");

                b.Property<int>("IDClient")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<int>("IDStore")
                    .IsRequired()
                    .HasColumnType("int");

                b.HasKey("InvoiceNum");

                b.HasIndex("IDClient");

                b.HasIndex("IDStore");

                b.ToTable("InvoiceHdr");
            });

            modelBuilder.Entity("Invoicing.DTOObjects.Models.InvoiceDtl", b =>
            {
                b.Property<int>("ID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                b.Property<string>("InvoiceNum")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<int>("Order")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<int>("IDProduct")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<double>("Price")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("numeric(18,2)");

                b.Property<int>("QTY")
                    .IsRequired()
                    .HasColumnType("int"); 

                b.HasKey("InvoiceNum");

                b.HasIndex("IDProduct");

                b.ToTable("InvoiceDtl");
            });








            modelBuilder.Entity("Invoicing.DTOObjects.Models.CreateUserCommand", b =>
            { 
                b.Property<string>("DocumentNumber")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<int>("DocumentTypeId")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("PhoneNumber")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<string>("Password")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

                b.Property<DateTime>("FirstLoginDate")
                    .IsRequired()
                    .HasColumnType("Date");

                b.HasKey("DocumentNumber");

                b.ToTable("CreateUserCommand");
            });

            base.BuildTargetModel(modelBuilder);
        }
    }
}
