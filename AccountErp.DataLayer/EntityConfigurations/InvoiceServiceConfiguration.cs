using AccountErp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountErp.DataLayer.EntityConfigurations
{
    public class InvoiceServiceConfiguration : IEntityTypeConfiguration<InvoiceService>
    {
        public void Configure(EntityTypeBuilder<InvoiceService> builder)
        {
            builder.ToTable("InvoiceServices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.InvoiceId).IsRequired();
            builder.Property(x => x.ServiceId).IsRequired();
            builder.Property(x => x.Rate).IsRequired().HasColumnType("NUMERIC(12,2)");

            builder.HasOne(x => x.Service).WithMany().HasForeignKey(x => x.ServiceId);
        }
    }
}
