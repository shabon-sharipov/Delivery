﻿using Delivery.Domain.Enam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Requests.OrderRequest
{
    public class CreateOrderRequest : OrderRequest
    {
        public string ShipAddress { get; set; }
        public DateTime ShipDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ulong UserId { get; set; }
        public ulong DriverId { get; set; }
        public string AvailableTo { get; set; }
        public bool IsPayment { get; set; }
    }
}
