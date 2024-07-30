using FluentValidation;

namespace Application.Features.Actors.Commands.Delete;

public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
{
    public DeleteActorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}