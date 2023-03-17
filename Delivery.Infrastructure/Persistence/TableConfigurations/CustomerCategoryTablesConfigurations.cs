using Delivery.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomerCategoryTablesConfigurations : IEntityTypeConfiguration<CategoryCustomer>
{
    public void Configure(EntityTypeBuilder<CategoryCustomer> builder)
    {

    }
}

