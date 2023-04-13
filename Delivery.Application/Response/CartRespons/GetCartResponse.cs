using Delivery.Application.Response;
using Delivery.Application.Response.CardItemResponse;
using Delivery.Application.Response.CartRespons;

public class GetCartResponse : CartResponse
{
    public ulong Id { get; set; }
    public virtual List<GetCardItemResponse> CardItems { get; set; }
    public decimal TotalPrice { get; set; }
    public ulong CurrentUserId { get; set; }
}
