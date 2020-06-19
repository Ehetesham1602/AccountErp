﻿using AccountErp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountErp.DataLayer.EntityConfigurations
{
    public class BillItemConfiguration : IEntityTypeConfiguration<BillItem>
    {
        public void Configure(EntityTypeBuilder<BillItem> builder)
        {
            builder.ToTable("BillServices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BillId).IsRequired();
            builder.Property(x => x.ItemId).IsRequired();
            builder.Property(x => x.Rate).IsRequired().HasColumnType("NUMERIC(10,2)");
            builder.Property(x => x.Price).IsRequired().HasColumnType("NUMERIC(10,2)");
            builder.Property(x => x.TaxId).IsRequired();
            builder.Property(x => x.TaxPercentage).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();

        }
    }
}
