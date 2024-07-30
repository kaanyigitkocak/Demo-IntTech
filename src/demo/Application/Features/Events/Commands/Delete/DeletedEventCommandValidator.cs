using FluentValidation;

namespace Application.Features.Events.Commands.Delete;

public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
{
    public DeleteEventCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}