using DTO.Resident;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.ResidentValidation
{
    public class ResidentInsertRequestValidator : AbstractValidator<ResidentInsertRequest>
    {
        public ResidentInsertRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
            RuleFor(x => x.TRIdNumber).NotEmpty().WithMessage("Turkish Republic identification number is required");
            RuleFor(x => x.Phone1).NotEmpty().WithMessage("Phone number is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is required and must be a valid email address");
            RuleFor(x => x.Tenant).NotEmpty().WithMessage("Tenant is required");
        }
    }
}