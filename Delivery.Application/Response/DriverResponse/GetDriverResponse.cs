using Delivery.Application.Respons;
using Delivery.Application.Response.SenderResponse;

public class GetDriverResponse : DriverResponse
{
    public ulong Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DataOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
