using Delivery.Application.Response;
using Delivery.Application.Response.MerchantResponse;

public  class PaggedMerchantListItemResponse : MerchantResponse
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string IsActive { get; set; }
}
