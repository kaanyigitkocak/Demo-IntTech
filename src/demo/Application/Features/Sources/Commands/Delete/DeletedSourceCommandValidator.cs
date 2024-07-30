using FluentValidation;

namespace Application.Features.Sources.Commands.Delete;

public class DeleteSourceCommandValidator : AbstractValidator<DeleteSourceCommand>
{
    public DeleteSourceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}