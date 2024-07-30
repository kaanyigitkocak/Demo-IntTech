using FluentValidation;

namespace Application.Features.Denemes.Commands.Create;

public class CreateDenemeCommandValidator : AbstractValidator<CreateDenemeCommand>
{
    public CreateDenemeCommandValidator()
    {
        RuleFor(c => c.ActivationKey).NotEmpty();
        RuleFor(c => c.IsVerified).NotEmpty();
    }
}