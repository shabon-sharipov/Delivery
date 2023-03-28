using Delivery.Application.Requests.SenderRequest;
using FluentValidation;

public class UdateDriverValidation : AbstractValidator<DriverRequest>
{
    public UdateDriverValidation()
    {
        RuleFor(s => s.FirstName).NotEmpty();
        RuleFor(s => s.Address).NotEmpty().NotNull();
        RuleFor(s => s.Email).EmailAddress();
        RuleFor(s => s.LastName).NotNull();
        RuleFor(s => s.Password).MaximumLength(8).MinimumLength(8);
    }
}
