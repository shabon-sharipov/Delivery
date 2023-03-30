using Delivery.Application.Requests.CustomerRequest;
using Delivery.Application.Response.CustomerResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Common.Interfaces
{
    public interface ICustomerService : IBaseService<Customer, CustomerResponse, CustomerRequest>
    {
    }
}
