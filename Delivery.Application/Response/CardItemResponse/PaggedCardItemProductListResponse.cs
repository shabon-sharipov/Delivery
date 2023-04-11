using Delivery.Application.Response.CardItemResponse;
using Delivery.Domain.Model;

public class PaggedCardItemProductListResponse : CardItemResponse
{
    public string Name { get; set; }
    public string Discription { get; set; }
    public decimal Price { get; set; }
    public ulong CategoryId { get; set; }
    public ulong MerchantId { get; set; }
    public bool IsActive { get; set; }
}