using Delivery.Application.Response;
using Delivery.Application.Response.CartRespons;

public class CreateCartRespons : CartResponse
{
    public decimal TotalPrice { get; set; }
    public ulong CurrentUserId { get; set; }
}
