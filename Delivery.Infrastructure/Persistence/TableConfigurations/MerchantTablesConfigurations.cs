using Delivery.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MerchantTablesConfigurations : IEntityTypeConfiguration<Merchant>
{
    public void Configure(EntityTypeBuilder<Merchant> builder)
    {
        builder.ToTable(nameof(Merchant));
        builder.HasKey(m => m.Id);

        builder.HasOne(m => m.MerchantCategory)
            .WithMany()
            .HasForeignKey(m => m.MerchantCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(m => m.Products)
            .WithOne(p => p.Merchant)
            .OnDelete(DeleteBehavior.Restrict);
    }
}