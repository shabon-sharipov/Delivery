using Delivery.Domain.Abstract;

public class Cart : EntityBase
{
    public virtual List<CartItem> Items { get; set; }
    public ulong CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
}
