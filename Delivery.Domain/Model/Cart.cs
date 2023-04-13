using Delivery.Domain.Abstract;

public class Cart : EntityBase
{
    public virtual List<CartItem> CardItems { get; set; }
    public ulong CurrentUserId { get; set; }
    public virtual Customer Person { get; set; }
}
