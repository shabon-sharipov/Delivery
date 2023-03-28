using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Response.SenderResponse;
using Delivery.Domain.Model;


namespace Delivery.Application.Common.Interfaces
{
    public interface IDriverService : IBaseService<Driver, DriverResponse, DriverRequest>
    {
    }
}
