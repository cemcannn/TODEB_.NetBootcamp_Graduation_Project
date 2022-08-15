using DTO.Message;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.MessageValidation
{
    public class MessageSendRequestValidator : AbstractValidator<MessageSendRequest>
    {
        public MessageSendRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().Length(5, 250).WithMessage("Description is required and must be between 10-250 characters.");
        }
    }
}
