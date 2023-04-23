using Delivery.Application.Response;
using Delivery.Application.Response.CartRespons;

public class CreateCartResponse : CartResponse
{
    public ulong Id { get; set; }
    public ulong CustomerId { get; set; }
}
