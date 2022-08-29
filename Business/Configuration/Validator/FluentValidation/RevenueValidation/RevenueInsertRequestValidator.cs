using DTO.Revenue;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.RevenueValidation
{
    public class RevenueInsertRequestValidator : AbstractValidator<RevenueInsertRequest>
    {
        public RevenueInsertRequestValidator()
        {
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Month).NotEmpty().WithMessage("Month is required");
            RuleFor(x => x.PropertyId).NotEmpty().WithMessage("Property Id is required");
        }
    }
}