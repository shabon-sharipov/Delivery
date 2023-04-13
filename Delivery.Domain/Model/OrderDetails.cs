using Delivery.Domain.Abstract;
using Delivery.Domain.Model;

public class OrderDetails : EntityBase
{
    public ulong OrderId { get; set; }
    public virtual Order Order { get; set; }

    public ulong ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}