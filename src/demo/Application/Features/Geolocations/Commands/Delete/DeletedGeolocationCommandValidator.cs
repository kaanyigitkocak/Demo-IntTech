using FluentValidation;

namespace Application.Features.Geolocations.Commands.Delete;

public class DeleteGeolocationCommandValidator : AbstractValidator<DeleteGeolocationCommand>
{
    public DeleteGeolocationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}