namespace Delivery.Application.Response.CategoryProductResponse;

public class PaggedListProductCategoryItemResponse: ProductCategoryResponse
{
    public ulong Id { get; set; }
    public string AvailableFrom { get; set; }
    public string AvailableTo { get; set; }
    public decimal TotalPrice { get; set; }
    public ulong DriverId { get; set; }
}