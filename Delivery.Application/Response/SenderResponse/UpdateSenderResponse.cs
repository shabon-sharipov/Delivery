using Delivery.Application.Respons;
using Delivery.Application.Respons.SenderResponse;

public class UpdateSenderResponse : SenderResponse
{
    public ulong Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
