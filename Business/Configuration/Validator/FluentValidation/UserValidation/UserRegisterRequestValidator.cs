using DTO.User;
using FluentValidation;
using System;

namespace Business.Configuration.Validator.FluentValidation.UserValidation
{
    public class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterRequestValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full Name is required");
            RuleFor(x => x.TRIdNumber).NotEmpty().WithMessage("Republic of Turkey Identification Number is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is required and must be a valid email address");
            RuleFor(x => x.Phone1).NotEmpty().WithMessage("Phone1 is required");
            RuleFor(x => x.Role).NotEmpty().WithMessage("Role is required");
            RuleFor(x => x.UserPermissions).NotEmpty().WithMessage("Permissions is required");
        }
    }
}
