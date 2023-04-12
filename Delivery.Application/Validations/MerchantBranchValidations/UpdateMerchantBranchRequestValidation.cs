using Delivery.Application.Requests.MerchantBranch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.MerchantBranchValidations
{
    public class UpdateMerchantBranchRequestValidation : AbstractValidator<UpdateMerchantBranchRequest>
    {
        public UpdateMerchantBranchRequestValidation()
        {
            RuleFor(m=>m.MerchantId).NotNull().NotEmpty();
            RuleFor(m=>m.Location).NotNull().NotEmpty();
        }
    }
}
