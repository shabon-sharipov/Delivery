using Delivery.Application.Requests.CategoryCustomerRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.CreateCategoryCustomerRequestValidation
{
    public class CreateCategoryCustomerRequestValidation : AbstractValidator<CreateCategoryCustomerRequest>
    {
        public CreateCategoryCustomerRequestValidation()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c=>c.Description).NotEmpty();
        }

    }
}
