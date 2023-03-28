using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderDetailsTablesConfigurations : IEntityTypeConfiguration<OrderDetails>
{
    public void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        builder.ToTable(nameof(OrderDetails));
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).ValueGeneratedOnAdd();

        builder.HasOne(o => o.Order)
            .WithMany()
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Product)
          .WithMany()
          .HasForeignKey(o => o.ProductId)
          .OnDelete(DeleteBehavior.Restrict);
    }
}
