using Delivery.Application.Respons;
using Delivery.Application.Response.SenderResponse;

public class DriverPaggedListItemResponse : DriverResponse
{
    public ulong Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}