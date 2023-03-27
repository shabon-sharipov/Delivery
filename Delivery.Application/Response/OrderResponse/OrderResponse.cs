using Delivery.Application.Respons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Respons.OrderResponse
{
    public abstract class OrderResponse : BaseResponse
    {
        public string PhoneNumber { get; set; }
        public string IsPayment { get; set; }
        public decimal TotalPrice { get; set; }
        public ulong SenderId { get; set; }
    }
}
