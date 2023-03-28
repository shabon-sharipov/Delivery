using Delivery.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MerchantCategoryTablesConfigurations : IEntityTypeConfiguration<MerchantCategory>
{
    public void Configure(EntityTypeBuilder<MerchantCategory> builder)
    {

    }
}

