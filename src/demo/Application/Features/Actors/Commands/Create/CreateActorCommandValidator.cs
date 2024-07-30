using FluentValidation;

namespace Application.Features.Actors.Commands.Create;

public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
{
    public CreateActorCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}