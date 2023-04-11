using Delivery.Application.Response.OrderResponse;
using Delivery.Domain.Enam;

public class PaggedOrderListItemResponse : OrderResponse
{
    public ulong Id { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public decimal TotalPrice { get; set; }
    public string AvailableTo { get; set; }
}