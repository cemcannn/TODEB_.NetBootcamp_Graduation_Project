using DTO.Vehicle;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.VehicleValidation
{
    public class VehicleInsertRequestValidator : AbstractValidator<VehicleInsertRequest>
    {
        public VehicleInsertRequestValidator()
        {
            RuleFor(x => x.Plate).NotEmpty().WithMessage("Plate is required");
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("Owner Id is required");
        }
    }
}