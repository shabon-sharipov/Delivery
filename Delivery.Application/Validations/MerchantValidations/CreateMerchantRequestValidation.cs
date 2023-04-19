using Delivery.Application.Requests.MerchantRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.MerchantValidations
{
    public class CreateMerchantRequestValidation : AbstractValidator<CreateMerchantRequest>
    {
        public CreateMerchantRequestValidation()
        {
            RuleFor(m => m.Name).NotEmpty().NotNull();
            RuleFor(m => m.ShortDiscreption).NotEmpty().Length(50);
            RuleFor(m => m.IsActive).NotEmpty();
            RuleFor(m => m.MerchantCategoryId).NotEmpty().NotNull();

        }
    }
}
