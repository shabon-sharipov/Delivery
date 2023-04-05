using Delivery.Application.Response;

public  class PaggedMerchantListItemResponse : BaseResponse
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string IsActive { get; set; }
}
