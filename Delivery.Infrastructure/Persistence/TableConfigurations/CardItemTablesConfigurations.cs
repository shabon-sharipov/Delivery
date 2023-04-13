using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CardItemTablesConfigurations : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable(nameof(CartItem));
        builder.HasKey(m => m.Id);

        builder.HasOne(cardItem => cardItem.Card)
            .WithMany(card => card.Items)
            .HasForeignKey(cardItem => cardItem.CardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cardItem => cardItem.Product)
           .WithMany()
           .HasForeignKey(cardItem => cardItem.ProductId)
           .OnDelete(DeleteBehavior.Restrict);


    }
}