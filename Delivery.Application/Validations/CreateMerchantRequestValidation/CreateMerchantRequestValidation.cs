using Delivery.Application.Requests.MerchantRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.CreateMerchantRequestValidation
{
    public class CreateMerchantRequestValidation : AbstractValidator<CreateMerchantRequest>
    {
        public CreateMerchantRequestValidation()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.ShortDiscreption).NotEmpty().MaximumLength(30);
            RuleFor(m => m.IsActive).NotEmpty().NotNull();
        }
    }
}
