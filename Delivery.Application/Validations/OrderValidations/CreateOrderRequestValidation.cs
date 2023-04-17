using Delivery.Application.Requests.OrderRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.OrderValidations
{
    public class CreateOrderRequestValidation : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidation()
        {
            RuleFor(o => o.AvailableTo).NotEmpty().NotNull();
            RuleFor(o => o.IsPayment).NotNull();
            RuleFor(o=>o.ShipAddress).NotNull().NotEmpty();
        }
    }
}
