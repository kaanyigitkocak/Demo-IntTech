using FluentValidation;

namespace Application.Features.Events.Commands.Update;

public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
    public UpdateEventCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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