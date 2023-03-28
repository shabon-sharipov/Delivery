using Delivery.Application.Requests.CategoryCustomerRequest;
using FluentValidation;

namespace Delivery.Application.Validations.CreateCategoryCustomerRequestValidation
{
    public class CreateMerchantCategoryRequestValidation : AbstractValidator<CreateMerchantCategoryRequest>
    {
        public CreateMerchantCategoryRequestValidation()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.ShortDescreption).NotEmpty();
        }
    }
}
