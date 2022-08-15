using DTO.Bill;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.BillValidation
{
    public class BillUpdateRequestValidator : AbstractValidator<BillUpdateRequest>
    {
        public BillUpdateRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Month).NotEmpty().WithMessage("Month is required");
        }
    }
}
