using DTO.Payment;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.PaymentValidation
{
    public class PayBillRequestValidator : AbstractValidator<PayBillRequest>
    {
        public PayBillRequestValidator()
        {
            RuleFor(x => x.PropertyId).NotEmpty().WithMessage("Property Id is required");
            RuleFor(x => x.BillId).NotEmpty().WithMessage("Bill Id is required");
        }
    }
}
