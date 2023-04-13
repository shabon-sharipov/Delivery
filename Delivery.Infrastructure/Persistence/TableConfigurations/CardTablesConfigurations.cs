using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CardTablesConfigurations : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable(nameof(Cart));
        builder.HasKey(m => m.Id);

        builder.HasMany(c => c.Items)
            .WithOne(cardItem => cardItem.Card)
            .HasForeignKey(cardItem => cardItem.CardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Customer)
            .WithMany()
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}