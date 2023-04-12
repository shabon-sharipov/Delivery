using Delivery.Application.Response.CardItemResponse;
using Delivery.Domain.Model;

public class PaggedListCardItemResponse : CartItemResponse
{
    public ulong Id { get; set; }
    public ulong CardId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}