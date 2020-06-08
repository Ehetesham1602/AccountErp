﻿// <auto-generated />
using System;
using AccountErp.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccountErp.DataLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200603134023_DbMigration030620")]
    partial class DbMigration030620
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccountErp.DataLayer.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<DateTime?>("LastLogOn");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AccountErp.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(1000);

                    b.Property<int?>("CountryId");

                    b.Property<int?>("CountryId1");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .HasMaxLength(100);

                    b.Property<string>("StreetName")
                        .HasMaxLength(100);

                    b.Property<string>("StreetNumber")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("CountryId1");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AccountErp.Entities.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountHolderName")
                        .HasMaxLength(250);

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(50);

                    b.Property<string>("BankName")
                        .HasMaxLength(100);

                    b.Property<string>("BranchName")
                        .HasMaxLength(250);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Ifsc")
                        .HasMaxLength(20);

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("AccountErp.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("NUMERIC(12,2)");

                    b.Property<DateTime?>("DueDate");

                    b.Property<string>("ReferenceNumber")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(1000);

                    b.Property<int>("Status");

                    b.Property<decimal?>("Tax")
                        .HasColumnType("NUMERIC(12,2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("NUMERIC(12,2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<int>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("AccountErp.Entities.BillAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("BillAttachments");
                });

            modelBuilder.Entity("AccountErp.Entities.BillItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BillId");

                    b.Property<int>("ItemId");

                    b.Property<decimal>("Rate")
                        .HasColumnType("NUMERIC(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ItemId");

                    b.ToTable("BillServices");
                });

            modelBuilder.Entity("AccountErp.Entities.BillPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("NUMERIC(12,2)");

                    b.Property<int?>("BankAccountId");

                    b.Property<int>("BillId");

                    b.Property<string>("ChequeNumber");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int?>("CreditCardId");

                    b.Property<string>("DepositTo")
                        .HasMaxLength(50);

                    b.Property<string>("Description");

                    b.Property<DateTime?>("PaymentDate");

                    b.Property<int>("PaymentMode");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.HasIndex("BillId");

                    b.ToTable("BillPayments");
                });

            modelBuilder.Entity("AccountErp.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("FirstName")
                        .HasMaxLength(250);

                    b.Property<string>("JobTitle")
                        .HasMaxLength(250);

                    b.Property<string>("LastName")
                        .HasMaxLength(250);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(250);

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<int>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("VendorId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("AccountErp.Entities.Country", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("IsoCode")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasMaxLength(1000);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AccountErp.Entities.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CardHolderName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("AccountErp.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(50);

                    b.Property<int?>("AddressId");

                    b.Property<string>("BankBranch")
                        .HasMaxLength(250);

                    b.Property<string>("BankName")
                        .HasMaxLength(250);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("NUMERIC(5,2)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Ifsc")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(250);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(250);

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<int?>("ShippingAddressId");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ShippingAddressId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AccountErp.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("CustomerId");

                    b.Property<int?>("CustomerId1");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("NUMERIC(12,2)");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(1000);

                    b.Property<int>("Status");

                    b.Property<decimal?>("Tax")
                        .HasColumnType("NUMERIC(12,2)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("NUMERIC(12,2)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerId1");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("AccountErp.Entities.InvoiceAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("InvoiceId");

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceAttachments");
                });

            modelBuilder.Entity("AccountErp.Entities.InvoicePayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("NUMERIC(12,2)");

                    b.Property<int?>("BankAccountId");

                    b.Property<string>("ChequeNumber");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DepositFrom")
                        .HasMaxLength(50);

                    b.Property<string>("Description");

                    b.Property<int>("InvoiceId");

                    b.Property<DateTime?>("PaymentDate");

                    b.Property<int>("PaymentMode");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoicePayments");
                });

            modelBuilder.Entity("AccountErp.Entities.InvoiceService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InvoiceId");

                    b.Property<decimal>("Rate")
                        .HasColumnType("NUMERIC(12,2)");

                    b.Property<int>("ServiceId");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("InvoiceServices");
                });

            modelBuilder.Entity("AccountErp.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<bool>("IsTaxable");

                    b.Property<int>("ItemTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<decimal>("Rate")
                        .HasColumnType("NUMERIC(12,2)");

                    b.Property<int?>("SalesTaxId");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("SalesTaxId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("AccountErp.Entities.ItemType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("AccountErp.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("AccountErp.Entities.SalesTax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<int>("Status");

                    b.Property<decimal>("TaxPercentage");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("SalesTaxes");
                });

            modelBuilder.Entity("AccountErp.Entities.ShippingAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<int?>("CountryId");

                    b.Property<string>("DeliveryInstruction");

                    b.Property<string>("PostalCode");

                    b.Property<string>("ShipTo");

                    b.Property<string>("State");

                    b.Property<string>("StreetName");

                    b.Property<string>("StreetNumber");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("ShippingAddress");
                });

            modelBuilder.Entity("AccountErp.Entities.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(50);

                    b.Property<string>("BankBranch")
                        .HasMaxLength(250);

                    b.Property<string>("BankName")
                        .HasMaxLength(250);

                    b.Property<int?>("BillingAddressId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("NUMERIC(5,2)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Fax")
                        .HasMaxLength(50);

                    b.Property<string>("Ifsc")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<string>("RegistrationNumber");

                    b.Property<int?>("ShippingAddressId");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<string>("Website")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("BillingAddressId");

                    b.HasIndex("ShippingAddressId");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AccountErp.Entities.Address", b =>
                {
                    b.HasOne("AccountErp.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("AccountErp.Entities.Country")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId1");
                });

            modelBuilder.Entity("AccountErp.Entities.Bill", b =>
                {
                    b.HasOne("AccountErp.Entities.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountErp.Entities.BillAttachment", b =>
                {
                    b.HasOne("AccountErp.Entities.Bill")
                        .WithMany("Attachments")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountErp.Entities.BillItem", b =>
                {
                    b.HasOne("AccountErp.Entities.Bill")
                        .WithMany("Items")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountErp.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountErp.Entities.BillPayment", b =>
                {
                    b.HasOne("AccountErp.Entities.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId");

                    b.HasOne("AccountErp.Entities.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountErp.Entities.Contact", b =>
                {
                    b.HasOne("AccountErp.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("AccountErp.Entities.Vendor")
                        .WithMany("Contacts")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountErp.Entities.Customer", b =>
                {
                    b.HasOne("AccountErp.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("AccountErp.Entities.ShippingAddress", "ShippingAddress")
                        .WithMany()
                        .HasForeignKey("ShippingAddressId");
                });

            modelBuilder.Entity("AccountErp.Entities.Invoice", b =>
                {
                    b.HasOne("AccountErp.Entities.Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountErp.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId1");
                });

            modelBuilder.Entity("AccountErp.Entities.InvoiceAttachment", b =>
                {
                    b.HasOne("AccountErp.Entities.Invoice")
                        .WithMany("Attachments")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountErp.Entities.InvoicePayment", b =>
                {
                    b.HasOne("AccountErp.Entities.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId");

                    b.HasOne("AccountErp.Entities.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountErp.Entities.InvoiceService", b =>
                {
                    b.HasOne("AccountErp.Entities.Invoice")
                        .WithMany("Services")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountErp.Entities.Item", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountErp.Entities.Item", b =>
                {
                    b.HasOne("AccountErp.Entities.ItemType", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountErp.Entities.SalesTax", "SalesTax")
                        .WithMany()
                        .HasForeignKey("SalesTaxId");
                });

            modelBuilder.Entity("AccountErp.Entities.ShippingAddress", b =>
                {
                    b.HasOne("AccountErp.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("AccountErp.Entities.Vendor", b =>
                {
                    b.HasOne("AccountErp.Entities.Address", "BillingAddress")
                        .WithMany()
                        .HasForeignKey("BillingAddressId");

                    b.HasOne("AccountErp.Entities.Address", "ShippingAddress")
                        .WithMany()
                        .HasForeignKey("ShippingAddressId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AccountErp.DataLayer.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AccountErp.DataLayer.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountErp.DataLayer.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AccountErp.DataLayer.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
