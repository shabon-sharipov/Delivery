﻿using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.CardItemResponse
{
    public class CreateCardItemResponse : CartItemResponse
    {
        public ulong Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public ulong MerchantId { get; set; }
    }
}
