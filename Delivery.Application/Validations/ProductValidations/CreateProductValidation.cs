﻿using Delivery.Application.Requests.ProductsRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.ProductValidations
{
    public class CreateProductValidation : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidation()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Discription).MinimumLength(20).MaximumLength(200);
            RuleFor(p => p.CategoryId).NotEmpty().NotNull();
            RuleFor(p => p.MerchantId).NotEmpty().NotNull();
            RuleFor(p => p.IsActive).NotEmpty().NotNull();
        }
    }
}
