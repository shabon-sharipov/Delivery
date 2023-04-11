using Delivery.Application.Respons;
using Delivery.Application.Response.SenderResponse;

public class UpdateDriverResponse : DriverResponse
{
    public ulong Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}
