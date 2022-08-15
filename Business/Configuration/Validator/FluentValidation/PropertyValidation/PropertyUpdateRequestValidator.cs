using DTO.Property;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.PropertyValidation
{
    public class PropertyUpdateRequestValidator : AbstractValidator<PropertyUpdateRequest>
    {
        public PropertyUpdateRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Section).NotEmpty().WithMessage("Section is required");
            RuleFor(x => x.Empty).NotEmpty().WithMessage("Property status is required");
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
            RuleFor(x => x.Floor).NotEmpty().WithMessage("Floor is required");
            RuleFor(x => x.Number).NotEmpty().WithMessage("Number is required");
        }
    }
}
