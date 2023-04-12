using Delivery.Domain.Abstract;

public class Cart : EntityBase
{
    public virtual List<CartItem> CardItems { get; set; }
    public decimal TotalPrice { get; set; }
    public ulong CurrentUserId { get; set; }
    public virtual Person Person { get; set; }
}
