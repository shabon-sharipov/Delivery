using Delivery.Application.Requests.CategoryCustomerRequest;
using FluentValidation;

namespace Delivery.Application.Validations.CreateCategoryCustomerRequestValidation
{
    public class CreateCategoryCustomerRequestValidation : AbstractValidator<CreateCategoryCustomerRequest>
    {
        public CreateCategoryCustomerRequestValidation()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.Description).NotEmpty();
        }
    }
}
