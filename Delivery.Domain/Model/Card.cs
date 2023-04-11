using Delivery.Domain.Abstract;

public class Card : EntityBase
{
    public virtual List<CardItem> CardItems { get; set; }
    public decimal TotalPrice { get; set; }
}
