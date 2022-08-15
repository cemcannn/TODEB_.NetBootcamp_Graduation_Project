using DTO.Bill;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.BillValidation
{
    public class BillInsertRequestValidator : AbstractValidator<BillInsertRequest>
    {
        public BillInsertRequestValidator()
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Month).NotEmpty().WithMessage("Date is required");
        }
    }
}
