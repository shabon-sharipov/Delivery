using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Requests.OrderRequest
{
    public class OrderRequest : BaseRequest
    {
        public string AvailableFrom { get; set; }
        public string AvailableTo { get; set;}
        public string PhoneNumber { get; set; }
        public bool IsPayment { get; set; }
        public decimal TotalPrice { get; set; }
        public ulong SenderId { get; set; }
    }
}
