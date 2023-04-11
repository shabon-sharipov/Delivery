using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CardItemTablesConfigurations : IEntityTypeConfiguration<CardItem>
{
    public void Configure(EntityTypeBuilder<CardItem> builder)
    {
        builder.ToTable(nameof(CardItem));
        builder.HasKey(m => m.Id);

        builder.HasOne(cardItem => cardItem.Card)
            .WithMany(card => card.CardItems)
            .HasForeignKey(cardItem => cardItem.CardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cardItem => cardItem.Product)
           .WithMany()
           .HasForeignKey(cardItem => cardItem.ProductId)
           .OnDelete(DeleteBehavior.Restrict);


    }
}