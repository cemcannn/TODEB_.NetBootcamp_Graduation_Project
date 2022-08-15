using DTO.Revenue;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.RevenueValidation
{
    public class RevenueUpdateRequestValidator : AbstractValidator<RevenueUpdateRequest>
    {
        public RevenueUpdateRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Month).NotEmpty().WithMessage("Month is required");
        }
    }
}
