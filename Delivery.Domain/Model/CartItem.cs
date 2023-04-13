using Delivery.Domain.Abstract;
using Delivery.Domain.Model;

public class CartItem : EntityBase
{
    public ulong CardId { get; set; }
    public virtual Cart Card { get; set; }
    public ulong ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}