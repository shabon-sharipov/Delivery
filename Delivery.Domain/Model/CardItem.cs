using Delivery.Domain.Abstract;
using Delivery.Domain.Model;

public class CardItem : EntityBase
{
    public ulong CardId { get; set; }
    public virtual Card Card { get; set; }
    public ulong ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}