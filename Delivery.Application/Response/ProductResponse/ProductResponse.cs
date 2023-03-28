using Delivery.Application.Response;

namespace Delivery.Application.Response.ProductResponse
{
    public abstract class ProductResponse : BaseResponse
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }
        public ulong CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
