using Delivery.Domain.Abstract;
using Delivery.Domain.Model;

public class MerchantBranch : EntityBase
{
    public ulong MerchantId { get; set; }
    public virtual Merchant Merchant { get; set; }

    public string Location { get; set; }
    public string MerchantCoverage { get; set; }
}
