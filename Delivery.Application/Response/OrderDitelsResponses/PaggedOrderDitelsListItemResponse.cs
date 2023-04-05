using Delivery.Application.Response.OrderDitelsResponses;

public class PaggedOrderDitelsListItemResponse : OrderDitelsResponse
{
    public ulong Id { get; set; }
    public ulong OrderId { get; set; }
    public ulong ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}