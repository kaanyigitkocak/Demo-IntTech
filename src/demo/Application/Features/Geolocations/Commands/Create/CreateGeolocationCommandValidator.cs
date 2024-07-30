using FluentValidation;

namespace Application.Features.Geolocations.Commands.Create;

public class CreateGeolocationCommandValidator : AbstractValidator<CreateGeolocationCommand>
{
    public CreateGeolocationCommandValidator()
    {
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.Admin1).NotEmpty();
        RuleFor(c => c.Admin2).NotEmpty();
        RuleFor(c => c.Latitude).NotEmpty();
        RuleFor(c => c.Longitude).NotEmpty();
    }
}