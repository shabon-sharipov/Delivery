using Delivery.Application.Respons.OrderResponse;

public class CreateOrderResponse : OrderResponse
{
    public string PhoneNumber { get; set; }
    public string IsPayment { get; set; }
    public decimal TotalPrice { get; set; }
    public ulong SenderId { get; set; }
}
