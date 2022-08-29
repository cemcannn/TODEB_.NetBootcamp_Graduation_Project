using DTO.Payment;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.PaymentValidation
{
    public class PayRevenueRequestValidator : AbstractValidator<PayRevenueRequest>
    {
        public PayRevenueRequestValidator()
        {
            RuleFor(x => x.PropertyId).NotEmpty().WithMessage("Property Id is required");
            RuleFor(x => x.RevenueId).NotEmpty().WithMessage("Revenue Id is required");
        }
    }
}
