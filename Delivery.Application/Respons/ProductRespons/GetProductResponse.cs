using Delivery.Application.Respons.ProductRespons;

public class GetProductResponse : ProductResponse
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Discription { get; set; }
    public decimal Price { get; set; }
    public ulong CategoryId { get; set; }
    public bool IsActive { get; set; }
}
