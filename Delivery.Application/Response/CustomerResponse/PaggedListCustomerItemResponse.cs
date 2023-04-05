using Delivery.Application.Response.CustomerResponse;

public class PaggedListCustomerItemResponse : CustomerResponse
{
    public ulong Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}