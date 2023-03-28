using Delivery.Application.Requests.SenderRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.SenderValidations
{
    public class CreateDriverValidation : AbstractValidator<DriverRequest>
    {
        public CreateDriverValidation()
        {
            RuleFor(s => s.FirstName).NotEmpty();
            RuleFor(s => s.Address).NotEmpty().NotNull();
            RuleFor(s => s.Email).EmailAddress();
            RuleFor(s => s.LastName).NotNull();
            RuleFor(s => s.Password).MaximumLength(8).MinimumLength(8);
        }
    }
}
