using Delivery.Application.Requests.SenderRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.SenderValidations
{
    public class CreateSenderValidation : AbstractValidator<SenderRequest>
    {
        public CreateSenderValidation()
        {
            RuleFor(s=>s.FirstName).NotEmpty();
            RuleFor(s=>s.Address).NotEmpty().NotNull();
        }
    }
}
