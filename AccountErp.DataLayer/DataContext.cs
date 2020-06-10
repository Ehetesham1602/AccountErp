﻿using AccountErp.DataLayer.EntityConfigurations;
using AccountErp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountErp.DataLayer
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillAttachment> BillAttachments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceAttachment> InvoiceAttachments { get; set; }
        public DbSet<InvoiceService> InvoiceServices { get; set; }
        public DbSet<InvoicePayment> InvoicePayments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<SalesTax> SalesTaxes { get; set; }
        public DbSet<BillPayment> BillPayments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationAttachment> QuotationAttachments { get; set; }
        public DbSet<QuotationService> QuotationServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new BillAttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new BillItemConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceAttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceServiceConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new ItemTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VendorConfiguration());
            modelBuilder.ApplyConfiguration(new BillPaymentConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new InvoicePaymentConfiguration());
            modelBuilder.ApplyConfiguration(new QuotationAttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new QuotationConfiguration());
            modelBuilder.ApplyConfiguration(new QuotationServicesConfiguration());
        }
    }
}
