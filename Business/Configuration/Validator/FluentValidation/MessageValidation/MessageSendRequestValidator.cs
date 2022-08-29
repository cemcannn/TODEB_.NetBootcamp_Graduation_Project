using DTO.Message;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.MessageValidation
{
    public class MessageSendRequestValidator : AbstractValidator<MessageSendRequest>
    {
        public MessageSendRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
