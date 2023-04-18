using Delivery.Application.Requests.SenderRequest;
using FluentValidation;

public class UdateDriverValidation : AbstractValidator<DriverRequest>
{
    public UdateDriverValidation()
    {
        RuleFor(s => s.FirstName).NotEmpty();
        RuleFor(s => s.Address).NotEmpty().NotNull();
        RuleFor(s => s.LastName).NotNull();
        RuleFor(s => s.DataOfBirth).NotEmpty();
        RuleFor(s => s.PhoneNumber).NotEmpty().NotNull();
    }
}
