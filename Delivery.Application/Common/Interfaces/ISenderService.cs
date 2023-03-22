using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Respons.SenderResponse;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Common.Interfaces
{
    public interface ISenderService : IBaseService<Sender, SenderResponse, CreateSenderRequest>
    {
    }
}
