using Delivery.Application.Requests.CustomerRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.CustomerValiations
{
    public class UpdateCustomerRequestValidation : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidation()
        {
            RuleFor(c => c.FirstName).NotEmpty().NotNull();
            RuleFor(c => c.LastName).NotEmpty().NotNull();
            RuleFor(c => c.PhoneNumber).NotNull().NotEmpty();
            RuleFor(c => c.DataOfBirth).NotNull().NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
        }
    }
}
