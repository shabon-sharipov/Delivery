
namespace Delivery.Application.Requests.ProductsRequest
{
    public abstract class ProductRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }
        public ulong CategoryId { get; set; }
        public ulong MerchantId { get; set; }
        public bool IsActive { get; set; }
    }
}
