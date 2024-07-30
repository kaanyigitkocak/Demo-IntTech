using FluentValidation;

namespace Application.Features.Sources.Commands.Create;

public class CreateSourceCommandValidator : AbstractValidator<CreateSourceCommand>
{
    public CreateSourceCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}