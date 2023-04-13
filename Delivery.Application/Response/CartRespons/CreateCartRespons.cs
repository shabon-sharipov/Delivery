using Delivery.Application.Response;
using Delivery.Application.Response.CartRespons;

public class CreateCartRespons : CartResponse
{
    public ulong Id { get; set; }
    public ulong CurrentUserId { get; set; }
}
