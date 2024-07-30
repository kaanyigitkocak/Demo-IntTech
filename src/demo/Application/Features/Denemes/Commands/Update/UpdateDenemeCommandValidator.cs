using FluentValidation;

namespace Application.Features.Denemes.Commands.Update;

public class UpdateDenemeCommandValidator : AbstractValidator<UpdateDenemeCommand>
{
    public UpdateDenemeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ActivationKey).NotEmpty();
        RuleFor(c => c.IsVerified).NotEmpty();
    }
}