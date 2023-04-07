namespace Delivery.Application.Response.CategoryCustomerResponse;

public class PaggedListMerchantCategoryItemResponse: MerchantCategoryResponse
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string IsActive { get; set; }
}