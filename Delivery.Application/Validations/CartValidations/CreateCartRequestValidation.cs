using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.CartValidations
{
    public class CreateCartRequestValidation : AbstractValidator<CreateCartRequest>
    {
        public CreateCartRequestValidation()
        {
            RuleFor(c=>c.CustomerId).NotEmpty();
        }
    }
}
