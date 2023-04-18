using Delivery.Application.Requests.CustomerRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.CustomerValiations
{
    public class CreateCustomerRequestValidation : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidation()
        {
            RuleFor(c => c.FirstName).NotEmpty().NotNull();
            RuleFor(c => c.LastName).NotEmpty().NotNull();
            RuleFor(c => c.PhoneNumber).NotEmpty().NotNull();
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.DataOfBirth).NotEmpty();
        }
    }
}
