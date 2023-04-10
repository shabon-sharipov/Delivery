using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MerchantBranchTablesConfigurations : IEntityTypeConfiguration<MerchantBranch>
{
    public void Configure(EntityTypeBuilder<MerchantBranch> builder)
    {
        builder.ToTable(nameof(MerchantBranch));
        builder.HasKey(m => m.Id);

        builder.HasOne(m => m.Merchant)
            .WithMany(mb => mb.MerchantBranchs)
            .HasForeignKey(c => c.MerchantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}