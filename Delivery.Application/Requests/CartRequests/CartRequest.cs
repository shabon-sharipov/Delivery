using Delivery.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Requests.CartRequests
{
    public abstract class CartRequest : BaseRequest
    {
        public ulong CurrentUserId { get; set; }
    }
}
