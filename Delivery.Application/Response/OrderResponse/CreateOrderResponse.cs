﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.OrderResponse
{
    public class CreateOrderResponse : OrderResponse
    {
        public string AvailableFrom { get; set; }
        public string AvailableTo { get; set; }
        public string PhoneNumber { get; set; }
        public string IsPayment { get; set; }
        public decimal TotalPrice { get; set; }
        public ulong SenderId { get; set; }
    }
}