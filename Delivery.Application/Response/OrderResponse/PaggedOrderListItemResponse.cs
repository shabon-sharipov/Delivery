using Delivery.Application.Response.OrderResponse;

public class PaggedOrderListItemResponse : OrderResponse
{
    public ulong Id { get; set; }
    public string AvailableFrom { get; set; }
    public string AvailableTo { get; set; }
    public decimal TotalPrice { get; set; }
    public ulong DriverId { get; set; }
}