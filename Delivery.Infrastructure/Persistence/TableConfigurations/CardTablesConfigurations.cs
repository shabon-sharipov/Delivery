using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CardTablesConfigurations : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.ToTable(nameof(Card));
        builder.HasKey(m => m.Id);

        builder.HasMany(c => c.CardItems)
            .WithOne(cardItem => cardItem.Card)
            .HasForeignKey(cardItem => cardItem.CardId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}