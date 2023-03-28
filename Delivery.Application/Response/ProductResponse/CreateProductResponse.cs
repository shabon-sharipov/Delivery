﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Response.ProductResponse
{
    public class CreateProductResponse : ProductResponse
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }
        public ulong CategoryId { get; set; }
        public bool IsActive { get; set; }

    }
}