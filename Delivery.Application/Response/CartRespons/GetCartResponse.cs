using Delivery.Application.Response;
using Delivery.Application.Response.CartRespons;

public class GetCartResponse : CartResponse
{
    public virtual List<CartItem> CardItems { get; set; }
    public decimal TotalPrice { get; set; }
    public ulong CurrentUserId { get; set; }
}
