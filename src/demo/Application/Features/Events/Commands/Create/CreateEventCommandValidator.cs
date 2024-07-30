using FluentValidation;

namespace Application.Features.Events.Commands.Create;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.EventType).NotEmpty();
        RuleFor(c => c.Actor1Id).NotEmpty();
        RuleFor(c => c.Actor2Id).NotEmpty();
        RuleFor(c => c.GeolocationId).NotEmpty();
        RuleFor(c => c.SourceId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Fatalities).NotEmpty();
    }
}