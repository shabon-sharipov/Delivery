using Delivery.Application.Requests.ProductsRequest;
using FluentValidation;

public class UpdateProductValidation : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidation()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull();
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Discription).MinimumLength(20).MaximumLength(200);
        RuleFor(p => p.CategoryId).NotEmpty().NotNull();
        RuleFor(p => p.MerchantId).NotEmpty().NotNull();
        RuleFor(p => p.IsActive).NotEmpty().NotNull();
    }
}
