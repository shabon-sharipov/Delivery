﻿using Delivery.Application.Requests.CategoryCustomerRequest;
using Delivery.Application.Response.CategoryCustomerResponse;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Common.Interfaces
{
    public interface IMerchantCategoryService : IBaseService<MerchantCategory, MerchantCategoryResponse, MerchantCategoryRequest>
    {
    }
}
