﻿using Delivery.Application.Requests.MerchantBranch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.MerchantBranchValidations
{
    public class CreateMerchantBranchRequestValidation : AbstractValidator<CreateMerchantBranchRequest>
    {
        public CreateMerchantBranchRequestValidation()
        {
            RuleFor(m => m.MerchantId).NotEmpty().NotNull();
            RuleFor(m => m.Location).NotEmpty().NotNull();
        }
    }
}
