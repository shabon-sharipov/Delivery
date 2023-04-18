using Delivery.Application.Requests.CategoryProductRequest;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Validations.CategoryProductValidations
{
    public class CreateCategoryProductValidation : AbstractValidator<CreateCategoryProductRequest>
    {
        public CreateCategoryProductValidation()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().Length(30);
            RuleFor(p => p.ShortDescreption).NotEmpty();
        }
    }
}
