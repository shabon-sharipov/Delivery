﻿using Delivery.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderTablesConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(Order));
        builder.HasKey(p => p.Id);

        builder.HasOne(o => o.Driver)
            .WithMany()
            .HasForeignKey(o => o.DriverId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Customer)
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.OrderDetails)
            .WithOne(o => o.Order)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Merchant)
            .WithMany()
            .HasForeignKey(m => m.MerchantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
