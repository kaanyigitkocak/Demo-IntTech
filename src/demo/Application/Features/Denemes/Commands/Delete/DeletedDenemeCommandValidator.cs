using FluentValidation;

namespace Application.Features.Denemes.Commands.Delete;

public class DeleteDenemeCommandValidator : AbstractValidator<DeleteDenemeCommand>
{
    public DeleteDenemeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}