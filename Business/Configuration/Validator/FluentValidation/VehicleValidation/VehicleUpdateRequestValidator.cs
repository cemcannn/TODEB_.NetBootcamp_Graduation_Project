using DTO.Vehicle;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.VehicleValidation
{
    public class VehicleUpdateRequestValidator : AbstractValidator<VehicleUpdateRequest>
    {
        public VehicleUpdateRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Plate).NotEmpty().WithMessage("Plate is required");
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("Owner Id is required");
        }
    }
}