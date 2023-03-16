namespace Delivery.Application.Respons.ProductRespons
{
    public class ProductResponse:BaseResponse
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }
        public ulong CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
